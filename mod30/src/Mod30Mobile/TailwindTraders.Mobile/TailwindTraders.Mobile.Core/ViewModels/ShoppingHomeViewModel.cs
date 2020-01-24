using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using TailwindTraders.Mobile.Helpers;
using TailwindTraders.Mobile.Models;
using TailwindTraders.Mobile.Services;
using Xamarin.Forms;
using System.Linq;
using Microsoft.AppCenter.Crashes;
using Plugin.XSnack;

namespace TailwindTraders.Mobile.ViewModels
{
    public class ShoppingHomeViewModel : BaseViewModel<ProductCategoryInfo>
    {
        ObservableCollection<RecommendedProductCategory> recommendedCategories;
        public ObservableCollection<RecommendedProductCategory> RecommendedCategories 
        {
            get => recommendedCategories;
            set => SetProperty(ref recommendedCategories, value);
        }

        ObservableCollection<Product> popularProducts;
        public ObservableCollection<Product> PopularProducts 
        {
            get => popularProducts;
            set => SetProperty(ref popularProducts, value);
        }

        ObservableCollection<Product> previouslySeen;
        public ObservableCollection<Product> PreviouslySeenProducts 
        {
            get => previouslySeen;
            set => SetProperty(ref previouslySeen, value);
        }

        public ShoppingHomeViewModel()
        {
            NavigateToProductCategoryCommand = new Command<string>(async (code) => await ExecuteNavigateToProductCategoryCommand(code));
            TakePhotoCommand = new Command(async () => await ExecuteTakePhotoCommand());


            RecommendedCategories = new ObservableCollection<RecommendedProductCategory>();
            PopularProducts = new ObservableCollection<Product>();
            PreviouslySeenProducts = new ObservableCollection<Product>();
        }

        public ICommand NavigateToProductCategoryCommand { get; }
        public ICommand TakePhotoCommand { get; }

        async Task ExecuteNavigateToProductCategoryCommand(string code)
        {
            var routingUrl = $"{RoutingConstants.ProductCategoryPage}?categoryCode={code}";

            await Shell.Current.GoToAsync(routingUrl, true);
        }
    
        async Task ExecuteTakePhotoCommand()
        {
            bool success = false;
            Stream photoStream;
            var photoService = new PhotoService();

            var result = await Shell.Current.DisplayActionSheet("Smart Shopping", "Cancel", null, "Take Photo", "Select from Camera Roll");

         
            if (result.Equals("Take Photo", StringComparison.OrdinalIgnoreCase))
                photoStream = await photoService.TakePhoto();
            else
                photoStream = await photoService.PickPhoto();

            if (photoStream == null)
                return;

            try
            {
                IsBusy = true;

                var storage = new AzureStorageService();
                var sas = await storage.GetSharedAccessSignature();

                if (!string.IsNullOrWhiteSpace(sas))
                {
                    success = await storage.UploadPhoto(photoStream, sas);
                }
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string> { { "Function", "ShoppingHomeViewModel.ExecuteTakePhotoCommand" } });
                return;
            }
            finally
            {
                IsBusy = false;
            }

            var message = success ? "Photo successfully uploaded" : "There was an error while uploading";
            var snack = DependencyService.Get<IXSnack>();
            await snack.ShowMessageAsync(message);
        }

        public async Task LoadData()
        {
            try
            {
                if (IsInitialized)
                    return;

                RecommendedCategories = null;

                RecommendedCategories = new ObservableCollection<RecommendedProductCategory>
                {
                    new RecommendedProductCategory { CategoryName = ProductCategoryConstants.SinkCategoryName, ImageName = "recommended_bathrooms",
                        CategoryAbbreviation = ProductCategoryConstants.SinkCategoryCode, NavigateCommand = NavigateToProductCategoryCommand },
                    new RecommendedProductCategory { CategoryName = ProductCategoryConstants.GardeningCategoryName, ImageName = "recommended_plants",
                        CategoryAbbreviation = ProductCategoryConstants.GardeningCategoryCode, NavigateCommand = NavigateToProductCategoryCommand },
                    new RecommendedProductCategory { CategoryName = ProductCategoryConstants.DIYToolsCategoryName, ImageName = "recommended_powertools",
                        CategoryAbbreviation = ProductCategoryConstants.DIYToolsCategoryCode, NavigateCommand = NavigateToProductCategoryCommand }
                };

                // Grab some data from the kitchen and hom appliances categories
                var kitchenItems = await DataStore.GetItemAsync(ProductCategoryConstants.KitchenCategoryCode);
                var appliances = await DataStore.GetItemAsync(ProductCategoryConstants.HomeAppliancesCategoryCode);

                PopularProducts = null;
                PopularProducts = new ObservableCollection<Product>(kitchenItems.Products.Take(3));

                PreviouslySeenProducts = null;
                PreviouslySeenProducts = new ObservableCollection<Product>(appliances.Products.Take(3));

                IsInitialized = true;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string> { { "Function", "ShoppingHomeViewModel.LoadData" } });
                IsInitialized = false;

                if (PopularProducts?.Count == 0)
                {
                    var popProd = new List<Product>();
                    popProd.Add(new Product { Name = "Wood Table", Price = 100, ImageUrl = new Uri("https://ttstorageucrqili3hgqvk.blob.core.windows.net/product-detail/19806834.jpg") });
                    PopularProducts = new ObservableCollection<Product>(popProd);

                    var prevProd = new List<Product>();
                    prevProd.Add(new Product { Name = "Microwave 0.9 Cu Ft 900 W", Price = 100, ImageUrl = new Uri("https://ttstorageucrqili3hgqvk.blob.core.windows.net/product-detail/10446729.jpg") });
                    PreviouslySeenProducts = new ObservableCollection<Product>(prevProd);
                }
            }
        }
    }
}
