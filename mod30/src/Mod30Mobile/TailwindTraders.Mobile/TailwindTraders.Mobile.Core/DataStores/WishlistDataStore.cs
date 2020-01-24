using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TailwindTraders.Mobile.Models;

namespace TailwindTraders.Mobile.Services
{
    public class WishlistDataStore : IDataStore<WishlistItem>
    {
        public Task<bool> AddItemAsync(WishlistItem item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<WishlistItem> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WishlistItem>> GetItemsAsync(bool forceRefresh = false)
        {
            var storageService = new AzureStorageService();

            return await storageService.GetWishlistItems();
        }

        public Task<bool> UpdateItemAsync(WishlistItem item)
        {
            throw new NotImplementedException();
        }
    }
}
