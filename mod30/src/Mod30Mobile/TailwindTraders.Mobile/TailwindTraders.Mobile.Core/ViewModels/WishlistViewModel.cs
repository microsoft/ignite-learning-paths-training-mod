using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TailwindTraders.Mobile.Models;
using Xamarin.Forms;

namespace TailwindTraders.Mobile.ViewModels
{
    public class WishlistViewModel : BaseViewModel<WishlistItem>
    {
        public WishlistViewModel()
        {
            RefreshWishlistCommand = new Command(async () => await ExecuteRefreshWishlistCommand());

            WishlistItems = new ObservableCollection<WishlistItem>();

            Title = "Wishlist";
        }

        ObservableCollection<WishlistItem> wishlistItems;
        public ObservableCollection<WishlistItem> WishlistItems { get => wishlistItems; set => SetProperty(ref wishlistItems, value); }

        public ICommand RefreshWishlistCommand { get; }

        public async Task ExecuteRefreshWishlistCommand ()
        {
            var theWishlist = await DataStore.GetItemsAsync();

            WishlistItems = new ObservableCollection<WishlistItem>(theWishlist);
        }
    }
}
