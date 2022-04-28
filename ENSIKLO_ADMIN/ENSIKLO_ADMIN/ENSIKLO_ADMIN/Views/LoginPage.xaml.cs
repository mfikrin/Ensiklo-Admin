using ENSIKLO_ADMIN.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ENSIKLO_ADMIN.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private readonly LoginViewModel _LoginViewModel;
        public LoginPage()
        {
            InitializeComponent();
            _LoginViewModel = Startup.Resolve<LoginViewModel>();
            BindingContext = _LoginViewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _LoginViewModel.OnAppearing();
        }
    }
}