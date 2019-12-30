using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using System.Drawing;
using System.Drawing.Imaging;
using Microsoft.Azure.WebJobs.Extensions.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using System.Collections.Generic;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

namespace Mod30Functions
{
    public static class TailwindFunctions
    {
        static string ConnectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");
        const string CONTAINER = "wishlist";
        const string DESCRIPTION = "description";

        [FunctionName(nameof(MakeThumbnailHttp))]
        public static async Task<IActionResult> MakeThumbnailHttp(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string blob = req.Query["blob"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            blob = blob ?? data?.blob;

            if (string.IsNullOrWhiteSpace(blob))
            {
                return new BadRequestObjectResult("Blob is required.");
            }
            else
            {
                try
                {
                    var result = await MakeThumb(blob, log);
                    return result ? (IActionResult)new OkResult() :
                        new BadRequestObjectResult("Already exists.");
                }
                catch (Exception ex)
                {
                    log.LogError(ex, "Thumbnail failed.");
                    return new BadRequestObjectResult("Unexpected failure.");
                }
            }
        }

        [FunctionName(nameof(MakeThumbnailEventGrid))]
        public static async Task MakeThumbnailEventGrid(
            [EventGridTrigger]EventGridEvent eventWrapper,
            ILogger log)
        {
            log.LogInformation("Event grid event received.");
            log.LogInformation(eventWrapper.Data.ToString());
            if (eventWrapper.Data is JObject blobEvent)
            {
                await MakeThumb(blobEvent["url"].Value<string>(), log);
            }
        }

        [FunctionName(nameof(GetWishlist))]
        public static async Task<IActionResult> GetWishlist(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            log.LogInformation("GetWishList invoked.");
            if (req == null)
            {
                throw new ArgumentNullException(nameof(req));
            }
            var result = new List<object>();
            var account = CloudStorageAccount.Parse(ConnectionString);
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(CONTAINER);
            BlobContinuationToken continuationToken = null;
            do
            {
                var response = await container.ListBlobsSegmentedAsync(continuationToken);
                continuationToken = response.ContinuationToken;
                foreach (var item in response.Results)
                {
                    var uri = item.Uri.ToString();
                    if (!uri.Contains("_thumb.jpg"))
                    {
                        var cloudBlob = new CloudBlob(item.Uri);
                        var blobRef = container.GetBlockBlobReference(cloudBlob.Name);
                        var description = string.Empty;
                        await blobRef.FetchAttributesAsync();
                        if (blobRef.Metadata.ContainsKey(DESCRIPTION))
                        {
                            description = blobRef.Metadata[DESCRIPTION];
                        }
                        var thumbRef = container.GetBlockBlobReference(cloudBlob.Name.Replace(".jpg", "_thumb.jpg"));
                        string thumbnail = await thumbRef.ExistsAsync() ?
                            uri.Replace(".jpg", "_thumb.jpg") : string.Empty;
                        var entry = new
                        {
                            Thumbnail = thumbnail,
                            Full = uri,
                            Description = description
                        };
                        result.Add(entry);
                    }
                }
            }
            while (continuationToken != null);
            return new OkObjectResult(result);
        }

        [FunctionName(nameof(UpdateDescription))]
        public static async Task<IActionResult> UpdateDescription(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("UpdateDescription invoked.");

            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            var blob = (string)data?.blob;
            var description = (string)data?.description;
            if (string.IsNullOrWhiteSpace(blob))
            {
                return new BadRequestObjectResult("Blob is required.");
            }
            if (string.IsNullOrWhiteSpace(description))
            {
                return new BadRequestObjectResult("Description is required.");
            }
            try
            {
                var uri = new Uri(blob);
                var cloudBlob = new CloudBlob(uri);
                var name = cloudBlob.Name;
                var account = CloudStorageAccount.Parse(ConnectionString);
                var client = account.CreateCloudBlobClient();
                var container = client.GetContainerReference(CONTAINER);
                var blockBlob = container.GetBlockBlobReference(name);
                var otherBlob =
                    container.GetBlockBlobReference(name.Replace(".jpg", "_thumb.jpg"));
                await UpdateMetadata(blockBlob, description);
                await UpdateMetadata(otherBlob, description);
                return new OkResult();
            }
            catch(Exception ex)
            {
                log.LogError(ex, "Unexpected error updating description.");
                return new BadRequestResult();
            }
        }

        [FunctionName(nameof(GetSASToken))]
        public static IActionResult GetSASToken(
           [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
           ILogger log)
        {
            var account = CloudStorageAccount.Parse(ConnectionString);
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(CONTAINER);

            var blobPolicy = new SharedAccessBlobPolicy
            {
                SharedAccessStartTime = DateTime.UtcNow.AddMinutes(-5),
                SharedAccessExpiryTime = DateTime.UtcNow.AddMinutes(20),
                Permissions = SharedAccessBlobPermissions.Create | SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write | SharedAccessBlobPermissions.List
            };

            var sas = container.GetSharedAccessSignature(blobPolicy);

            return new OkObjectResult(sas);
        }

        private static async Task UpdateMetadata(CloudBlockBlob blob, string description)
        {
            if (blob != null && await blob.ExistsAsync())
            {
                blob.Metadata[DESCRIPTION] = description;
                await blob.SetMetadataAsync();
            }
        }

        private static bool ThumbnailCallback() => false;

        private static async Task<bool> MakeThumb(string url, ILogger log)
        {
            log.LogInformation("Attempting to process url {url}", url);
            if (url.Contains("_thumb.jpg"))
            {
                log.LogInformation("URL passed is thumbnail.");
                return false;
            }
            var uri = new Uri(url);
            var cloudBlob = new CloudBlob(uri);
            var name = cloudBlob.Name;
            var account = CloudStorageAccount.Parse(ConnectionString);
            var client = account.CreateCloudBlobClient();
            var container = client.GetContainerReference(CONTAINER);
            var blockBlob = container.GetBlockBlobReference(name);
            using (var inputStream = await blockBlob.OpenReadAsync())
            {
                var thumb = container.GetBlockBlobReference(name.Replace(".jpg", "_thumb.jpg"));
                log.LogInformation("Processing thumbnail with URL: {url}", thumb.Uri);
                if (await thumb.ExistsAsync())
                {
                    log.LogInformation("Thumbnail already exists.");
                    return false;
                }
                using (var thumbStream = new MemoryStream())
                {
                    var image = Image.FromStream(inputStream);
                    var abortCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                    var thumbnailImage = image.GetThumbnailImage(200, 200, abortCallback, IntPtr.Zero);
                    thumbnailImage.Save(thumbStream, ImageFormat.Jpeg);
                    thumbStream.Position = 0;
                    await thumb.UploadFromStreamAsync(thumbStream);
                }
                thumb.Properties.ContentType = "image/jpeg";
                await thumb.SetPropertiesAsync();

                // transfer description if one exists
                await blockBlob.FetchAttributesAsync();
                if (blockBlob.Metadata.ContainsKey(DESCRIPTION))
                {
                    await UpdateMetadata(thumb, blockBlob.Metadata[DESCRIPTION]);
                }
            }           
            return true;
        }
    }
}