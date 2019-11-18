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
    public partial class FlyoutHeader : ContentView
    {
        public FlyoutHeader()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty PhotoCommandProperty = BindableProperty.Create(nameof(PhotoCommand), typeof(Command), typeof(FlyoutHeader));
        public Command PhotoCommand
        {
            get => (Command)GetValue(PhotoCommandProperty);
            set => SetValue(PhotoCommandProperty, value);
        }
    }
}