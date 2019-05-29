using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DbApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private readonly MainViewModel vm;

        public MainPage()
        {
            vm = new MainViewModel();
            BindingContext = vm;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            await vm.InitAsync();
            base.OnAppearing();
        }

    }
}
