using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TailwindTraders.Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PreviouslySeenProductView : ContentView
    {
        public PreviouslySeenProductView()
        {
            InitializeComponent();
            ShowCost = true;
        }

        public static readonly BindableProperty ProductImageProperty = BindableProperty.Create(nameof(ProductImage), typeof(string), typeof(PreviouslySeenProductView));
        public string ProductImage
        {
            get => (string)GetValue(ProductImageProperty);
            set => SetValue(ProductImageProperty, value);
        }

        public static readonly BindableProperty ProductCostProperty = BindableProperty.Create(nameof(ProductCost), typeof(string), typeof(PreviouslySeenProductView));
        public string ProductCost
        {
            get => (string)GetValue(ProductCostProperty);
            set => SetValue(ProductCostProperty, value);
        }

        public static readonly BindableProperty ProductNameProperty = BindableProperty.Create(nameof(ProductName), typeof(string), typeof(PreviouslySeenProductView));
        public string ProductName
        {
            get => (string)GetValue(ProductNameProperty);
            set => SetValue(ProductNameProperty, value);
        }

        public static readonly BindableProperty ShowCostProperty = BindableProperty.Create(nameof(ShowCost), typeof(bool), typeof(PreviouslySeenProductView));

        public bool ShowCost 
        {
            get => (bool)GetValue(ShowCostProperty);
            set => SetValue(ShowCostProperty, value);
        }
    }
}