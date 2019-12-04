using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using TailwindTraders.Mobile.Models;
using Xamarin.Forms;

namespace TailwindTraders.Mobile.ViewModels
{
    [QueryProperty("ProductName", "productName")]
    [QueryProperty("Price", "price")]
    [QueryProperty("ImageUrl", "imageUrl")]
    [QueryProperty("BrandName", "brandName")]
    [QueryProperty("CategoryCode", "categoryCode")]
    [QueryProperty("QuantityRemaining", "quantityRemaining")]
    public class ProductDetailViewModel : BaseViewModel<ProductCategoryInfo>
    {
        string productName;
        public string ProductName { get => productName;
            set
            {
                SetProperty(ref productName, Uri.UnescapeDataString(value));
            }
        }

        string price;
        public string Price { get => price; set => SetProperty(ref price, value); }

        string imageUrl;
        public string ImageUrl { get => imageUrl;
            set
            {
                SetProperty(ref imageUrl, Uri.UnescapeDataString(value));
            }
        }

        string brandName;
        public string BrandName { get => brandName; set => SetProperty(ref brandName, value); }

        string categoryCode;
        public string CategoryCode { get => categoryCode; set => SetProperty(ref categoryCode, value); }

        string quantityRemaining;
        public string QuantityRemaining { get => quantityRemaining; set => SetProperty(ref quantityRemaining, value); }

        public ObservableCollection<Product> SimilarProducts { get; set; }

        public ProductDetailViewModel()
        {
            SimilarProducts = new ObservableCollection<Product>();
        }

        public async Task LoadSimilarProducts()
        {
            if (IsInitialized)
                return;

            // Get products from the same category (making sure not to duplicate the same one)
            var categoryInfo = await DataStore.GetItemAsync(categoryCode);

            var similarProducts = categoryInfo.Products.Where(p => p.Name != ProductName).Take(3);

            foreach (var item in similarProducts)
            {
                SimilarProducts.Add(item);
            }

            IsInitialized = true;
        }
    }
}