using ENSIKLO_ADMIN.Services;
using ENSIKLO_ADMIN.Models;
using ENSIKLO_ADMIN.Views;
using System;
using System.Diagnostics;
using System.Net;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace ENSIKLO_ADMIN.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAdminService _adminService; // nanti ganti jadi service buat register dan login
        public Command LoginCommand { get; }

        public Command TappedCommand { get; }

        public string email;
        public string password;
        public LoginViewModel(IAdminService adminService)
        {
            _adminService = adminService;
            LoginCommand = new Command(async () => await OnLoginClicked(), ValidateLogin);


            PropertyChanged +=
            (_, __) => LoginCommand.ChangeCanExecute();
        }


        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        private async Task OnLoginClicked()
        {
            try
            {
                Debug.WriteLine(email);
                Debug.WriteLine(!String.IsNullOrWhiteSpace(email));
                Debug.WriteLine(password);
                Debug.WriteLine(!String.IsNullOrWhiteSpace(password));
                Debug.WriteLine("Doing login");
                var req = new LoginRequest
                {
                    Email = email,
                    Password = password,
                };

                string token = await _adminService.LoginAdminAsync(req);

                Debug.WriteLine(token);

                CurrentUser.Token = token;

                Admin gotAdmin = await _adminService.GetCurrentAdmin();

                CurrentUser.Id = gotAdmin.Id;
                CurrentUser.Email = gotAdmin.Email;
                CurrentUser.Username = gotAdmin.Username;

                Debug.WriteLine(gotAdmin.Email);
                Debug.WriteLine("token = " + CurrentUser.Token);
                Debug.WriteLine("username = " + CurrentUser.Username);

                await Shell.Current.GoToAsync("//main/home");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await App.Current.MainPage.DisplayAlert("Login Failed", "Please Check username or password", "OK");
            }
        }

        //private async void onTapped(object obj)
        //{
        //    await Shell.Current.GoToAsync("//register");
        //}
        private bool ValidateLogin()
        {
            return !String.IsNullOrWhiteSpace(email)
               && !String.IsNullOrWhiteSpace(password)
               ;
        }

        public void OnAppearing()
        {
            Email = "";
            Password = "";
        }
    }
}
