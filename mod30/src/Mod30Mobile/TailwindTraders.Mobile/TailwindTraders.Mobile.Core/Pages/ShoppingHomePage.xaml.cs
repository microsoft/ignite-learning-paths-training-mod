using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TailwindTraders.Mobile.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TailwindTraders.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingHomePage : ContentPage
    {
        public ShoppingHomePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (!(BindingContext is ShoppingHomeViewModel vm))
                return;
           
            await vm.LoadData();

        }
    }
}