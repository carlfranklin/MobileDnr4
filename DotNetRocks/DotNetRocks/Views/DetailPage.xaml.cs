using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DotNetRocks.Services;
using DotNetRocks.ViewModels;

namespace DotNetRocks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ShowNumber), nameof(ShowNumber))]
    public partial class DetailPage : ContentPage
    {
        public string ShowNumber { get; set; }
        ApiService ApiService = new ApiService();

        public DetailPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            int.TryParse(ShowNumber, out int result);
            var viewModel = (DetailPageViewModel)BindingContext;
            viewModel.CurrentShow = await ApiService.GetShowWithDetails(result);
        }

        protected override async void OnDisappearing()
        {
            var viewModel = (DetailPageViewModel)BindingContext;
            await viewModel.PerformStop();
        }
        
    }
}