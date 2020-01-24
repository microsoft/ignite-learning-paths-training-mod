using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.AppCenter.Crashes;
using Plugin.XSnack;
using TailwindTraders.Mobile.Helpers;
using TailwindTraders.Mobile.Services;
using Xamarin.Forms;

namespace TailwindTraders.Mobile.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        public ICommand NavigateToProductCategoryCommand { get; }
        public ICommand TakePhotoCommand { get; }

        public AppShellViewModel()
        {
            NavigateToProductCategoryCommand = new Command<string>(async (code) => await ExecuteNavigateToProductCategoryCommand(code));
            TakePhotoCommand = new Command(async () => await ExecuteTakePhotoCommand());
        }

        private async Task ExecuteNavigateToProductCategoryCommand(string code)
        {
            var routeWithData = $"{RoutingConstants.ProductCategoryPage}?categoryCode={code}";

            await Shell.Current.GoToAsync(routeWithData, true);
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

            try
            {
                IsBusy = true;

                var storage = new AzureStorageService();
                var sas = await storage.GetSharedAccessSignature();

                if (!(string.IsNullOrWhiteSpace(sas)))
                {
                    success = await storage.UploadPhoto(photoStream, sas);
                }

                Shell.Current.FlyoutIsPresented = false;
            }
            catch (Exception ex)
            {
                Crashes.TrackError(ex, new Dictionary<string, string> { { "Function", "AzureShellViewModel.ExecuteTakePhotoCommand" } });
            }
            finally
            {
                IsBusy = false;
            }
            
            var message = success ? "Photo successfully uploaded" : "There was an error while uploading";
            var snack = DependencyService.Get<IXSnack>();
            await snack.ShowMessageAsync(message);
        }
    }    
}
