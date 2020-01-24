using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TailwindTraders.Mobile.Models;

namespace TailwindTraders.Mobile.Services
{
    public class ProductCategoryDataStore : IDataStore<ProductCategoryInfo>
    {
        public Task<bool> AddItemAsync(ProductCategoryInfo item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductCategoryInfo> GetItemAsync(string categoryCode)
        {
            var productSvc = new ProductService();

            return await productSvc.GetProductsForCategory<ProductCategoryInfo>(categoryCode, false);
        }

        public Task<IEnumerable<ProductCategoryInfo>> GetItemsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(ProductCategoryInfo item)
        {
            throw new NotImplementedException();
        }
    }
}
