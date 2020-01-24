using System;
using System.Collections.Generic;
using TailwindTraders.Mobile.Helpers;
using TailwindTraders.Mobile.Pages;
using Xamarin.Forms;

namespace TailwindTraders.Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(RoutingConstants.ProductCategoryPage, typeof(ProductCategoryCollectionPage));
            Routing.RegisterRoute(RoutingConstants.ProductDetailPage, typeof(ProductDetailPage));
        }
    }
}
