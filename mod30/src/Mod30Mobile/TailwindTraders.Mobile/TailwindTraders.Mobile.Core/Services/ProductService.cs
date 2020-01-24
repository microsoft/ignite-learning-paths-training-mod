using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TailwindTraders.Mobile.Models;

using System.Net.Http;
using Xamarin.Essentials;
using TailwindTraders.Mobile.Helpers;
using Newtonsoft.Json;
using MonkeyCache.SQLite;
using Microsoft.AppCenter.Crashes;

namespace TailwindTraders.Mobile.Services
{
    public class ProductService
    {
        static HttpClient httpClient;
        public ProductService()
        {
            httpClient = new HttpClient();
        }

        public async Task<T> GetProductsForCategory<T>(string categoryCode, bool forceRefresh)
        {
            // Get the product service url
            var apiUrl = Preferences.Get(PreferencesConstants.ProductApiUrlKey, PreferencesConstants.DemoProductsApiUrl);

            var categoryUrl = $"{apiUrl}?type={categoryCode}";

            var json = string.Empty;

            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                json = Barrel.Current.Get<string>(categoryUrl);

            if (!forceRefresh && !Barrel.Current.IsExpired(categoryUrl))
                json = Barrel.Current.Get<string>(categoryUrl);

            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    json = await httpClient.GetStringAsync(categoryUrl);
                    Barrel.Current.Add(categoryUrl, json, TimeSpan.FromDays(14));
                }

                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string> { { "Function", "ProductService.GetProductsForCategory" } });
            }

            return default(T);
        }
    }
}
