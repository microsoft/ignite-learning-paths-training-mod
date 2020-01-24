using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TailwindTraders.Mobile.Models;
using Xamarin.Forms;
using TailwindTraders.Mobile.Helpers;

namespace TailwindTraders.Mobile.ViewModels
{
    public class ProductCategoryCollectionViewModel : BaseViewModel<ProductCategoryInfo>
    {
        ObservableCollection<Product> products;
        public ObservableCollection<Product> Products { get => products; set => SetProperty(ref products, value); }

        string categoryCode;
        public string CategoryCode { get => categoryCode; set => SetProperty(ref categoryCode, value); }

        Product selectedProduct;
        public Product SelectedProduct { get => selectedProduct; set => SetProperty(ref selectedProduct, value); }

        public ICommand LoadProductsCommand { get; }

        public ICommand SelectProductCommand { get; }

        public ProductCategoryCollectionViewModel()
        {
            Products = new ObservableCollection<Product>();

            LoadProductsCommand = new Command(async () => await ExecuteLoadProductsCommand());
            SelectProductCommand = new Command(async () => await ExecuteSelectProductCommand());
        }

        async Task ExecuteLoadProductsCommand()
        {
            IsBusy = true;

            var allProducts = await DataStore.GetItemAsync(CategoryCode);

            Title = allProducts.Types.FirstOrDefault(t => t.Code == CategoryCode)?.Name;
            
            Products = new ObservableCollection<Product>(allProducts.Products);

            IsBusy = false;
        }
    
        async Task ExecuteSelectProductCommand()
        {
            // put the query parameters together
            var productName = $"productName={Uri.EscapeDataString(SelectedProduct.Name)}";
            var price = $"price={SelectedProduct.Price}";
            var imageUrl = $"imageUrl={Uri.EscapeDataString(SelectedProduct.ImageUrl.ToString())}";
            var brandName = $"brandName={SelectedProduct.Brand.Name}";
            var categoryCode = $"categoryCode={CategoryCode}";
            var quantityRemaining = $"quantityRemaining={SelectedProduct.StockUnits}";

            var queryString = $"?{productName}&{price}&{imageUrl}&{brandName}&{categoryCode}&{quantityRemaining}";

            var route = $"{RoutingConstants.ProductDetailPage}{queryString}";

            await Shell.Current.GoToAsync(route, true);
        }
    
    }
}
