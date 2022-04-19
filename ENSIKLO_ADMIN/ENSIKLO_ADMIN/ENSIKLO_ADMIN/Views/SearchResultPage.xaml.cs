using ENSIKLO_ADMIN.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ENSIKLO_ADMIN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchResultPage : ContentPage
    {
        private readonly SearchResultViewModel _searchResultViewModel;
        public SearchResultPage()
        {
            InitializeComponent();
            _searchResultViewModel = Startup.Resolve<SearchResultViewModel>();
            BindingContext = _searchResultViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}