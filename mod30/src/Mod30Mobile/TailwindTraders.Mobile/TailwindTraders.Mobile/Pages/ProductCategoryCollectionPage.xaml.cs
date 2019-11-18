using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailwindTraders.Mobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TailwindTraders.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty("CategoryCode", "categoryCode")]
    public partial class ProductCategoryCollectionPage : ContentPage
    {
        public ProductCategoryCollectionPage()
        {
            InitializeComponent();
        }

        public string CategoryCode
        {
            set
            {
                if (!(BindingContext is ProductCategoryCollectionViewModel vm))
                    return;

                vm.CategoryCode = value;
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Shell.Current.FlyoutIsPresented = false;

            if (!(BindingContext is ProductCategoryCollectionViewModel vm))
                return;

            vm.LoadProductsCommand.Execute(null);
        }
    }
}