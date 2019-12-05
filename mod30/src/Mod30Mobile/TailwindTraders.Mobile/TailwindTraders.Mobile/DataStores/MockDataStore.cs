using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TailwindTraders.Mobile.Models;

namespace TailwindTraders.Mobile.Services
{
    public class MockDataStore : IDataStore<RecommendedProductCategory>
    {
        readonly List<RecommendedProductCategory> items;

        public MockDataStore()
        {
            items = new List<RecommendedProductCategory>();
           
        }

        public async Task<bool> AddItemAsync(RecommendedProductCategory item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(RecommendedProductCategory item)
        {
            
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
           

            return await Task.FromResult(true);
        }

        public async Task<RecommendedProductCategory> GetItemAsync(string id)
        {
            return await Task.FromResult(new RecommendedProductCategory());
        }

        public Task<IEnumerable<RecommendedProductCategory>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }
    }
}