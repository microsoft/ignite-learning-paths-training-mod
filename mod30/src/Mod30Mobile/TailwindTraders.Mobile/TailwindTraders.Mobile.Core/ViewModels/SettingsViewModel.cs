using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.XSnack;
using TailwindTraders.Mobile.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace TailwindTraders.Mobile.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        

        public SettingsViewModel()
        {
            SaveSettingsCommand = new Command(async() => await ExecuteSaveSettingsCommand());

            // Load the preferences up - doing it in the constructor cuz it should be fast
            ProductsAPIUrl = Preferences.Get(PreferencesConstants.ProductApiUrlKey, PreferencesConstants.DemoProductsApiUrl);
            StorageAccountName = Preferences.Get(PreferencesConstants.StorageAccountNameKey, PreferencesConstants.DemoStorageName);
            FunctionAppUrl = Preferences.Get(PreferencesConstants.FunctionAppUrlKey, PreferencesConstants.DemoFunctionsUrl);
        }

        string productsApiUrl;
        public string ProductsAPIUrl { get => productsApiUrl; set => SetProperty(ref productsApiUrl, value); }

        string storageAccountName;
        public string StorageAccountName { get => storageAccountName; set => SetProperty(ref storageAccountName, value); }

        string functionAppUrl;
        public string FunctionAppUrl { get => functionAppUrl; set => SetProperty(ref functionAppUrl, value); }

        public ICommand SaveSettingsCommand { get; }

        async Task ExecuteSaveSettingsCommand()
        {
            // Save everything to the preferences
            Preferences.Set(PreferencesConstants.ProductApiUrlKey, ProductsAPIUrl);
            Preferences.Set(PreferencesConstants.StorageAccountNameKey, StorageAccountName);
            Preferences.Set(PreferencesConstants.FunctionAppUrlKey, FunctionAppUrl); 
            
            var message = "Settings Successfully Saved";
            var snack = DependencyService.Get<IXSnack>();
            await snack.ShowMessageAsync(message);
        }
    }
}
