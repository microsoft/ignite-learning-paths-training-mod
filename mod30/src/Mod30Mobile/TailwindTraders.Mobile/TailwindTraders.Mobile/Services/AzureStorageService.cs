using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AppCenter.Crashes;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using Newtonsoft.Json;
using TailwindTraders.Mobile.Helpers;
using TailwindTraders.Mobile.Models;
using Xamarin.Essentials;

namespace TailwindTraders.Mobile.Services
{
    public class AzureStorageService
    {
        static readonly HttpClient httpClient = new HttpClient();

        public async Task<string> GetSharedAccessSignature()
        {
            try
            {
                var functionUrl = Preferences.Get(PreferencesConstants.FunctionAppUrlKey, PreferencesConstants.DemoFunctionsUrl);

                var sas = await httpClient.GetStringAsync($"{functionUrl}/getsastoken");

                return sas;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string> { { "Function", "AzureStorageService.GetSharedAccessSignature" } });
            }
            return string.Empty;
        }

        public async Task<IEnumerable<WishlistItem>> GetWishlistItems()
        {
            var functionUrl = Preferences.Get(PreferencesConstants.FunctionAppUrlKey, PreferencesConstants.DemoFunctionsUrl);

            var wishlistJson = await httpClient.GetStringAsync($"{functionUrl}/getwishlist");

            return JsonConvert.DeserializeObject<List<WishlistItem>>(wishlistJson);
        }

        public async Task<bool> UploadPhoto(Stream photo, string sharedAccessSignature)
        {
            try
            {
                var creds = new Microsoft.Azure.Storage.Auth.StorageCredentials(sharedAccessSignature);

                var storageAccountName = Preferences.Get(PreferencesConstants.StorageAccountNameKey,
                    PreferencesConstants.DemoStorageName);

                var account = new CloudStorageAccount(creds, storageAccountName, "core.windows.net", true);

                var blobClient = account.CreateCloudBlobClient();

                var container = blobClient.GetContainerReference("wishlist");

                var blockBlob = container.GetBlockBlobReference($"TT-{Guid.NewGuid()}.jpg");

                await blockBlob.UploadFromStreamAsync(photo);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string> { { "Function", "AzureStorageService.UploadPhoto" } });
                return false;
            }

            return true;
        }
    }
}
