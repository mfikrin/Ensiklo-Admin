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
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = Startup.Resolve<LoginViewModel>();
        }


        //protected override async void OnAppearing()
        //{
        //    base.OnAppearing();
        //    var loggedIn = true;
        //    if (loggedIn)
        //    {
        //        Debug.WriteLine("Sudah pernah login in login page");
        //        await Shell.Current.GoToAsync("//main");
        //    }
        //}
    }
}