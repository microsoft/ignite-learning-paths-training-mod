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
    public partial class WishlistPage : ContentPage
    {
        public WishlistPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            if (!(BindingContext is WishlistViewModel vm))
                return;

            await vm.ExecuteRefreshWishlistCommand();
        }
    }
}