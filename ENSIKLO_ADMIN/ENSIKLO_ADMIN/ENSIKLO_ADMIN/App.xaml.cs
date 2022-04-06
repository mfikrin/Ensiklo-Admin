using ENSIKLO_ADMIN.Services;
using ENSIKLO_ADMIN.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ENSIKLO_ADMIN
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Startup.ConfigureServices();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
