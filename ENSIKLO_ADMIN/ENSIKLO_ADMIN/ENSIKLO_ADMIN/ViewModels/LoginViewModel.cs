using ENSIKLO_ADMIN.Services;
using ENSIKLO_ADMIN.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ENSIKLO_ADMIN.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IBookService _bookService; // nanti ganti jadi service buat register dan login
        public Command LoginCommand { get; }

        public Command TappedCommand { get; }

        public LoginViewModel(IBookService bookService)
        {
            _bookService = bookService;
            LoginCommand = new Command<string>(OnLoginClicked);

            TappedCommand = new Command(onTapped);
        }

        private async void OnLoginClicked(string role)
        {
            // Prefixing with `//` switches to a different navigation stack instead of pushing to the active one

            // NANTI UNCOMMENT INI

            //if (role.Equals("Admin"){
            //    await Shell.Current.GoToAsync($"//admin/homeAdmin");
            //}
            //else if (role.Equals("User"))
            //{
            //    await Shell.Current.GoToAsync($"//main/home");
            //}



            await Shell.Current.GoToAsync("//admin/homeAdmin");
            //await Shell.Current.GoToAsync($"//main/home");
            //await Shell.Current.GoToAsync($"//admin/homeAdmin");

        }

        private async void onTapped(object obj)
        {
            await Shell.Current.GoToAsync("//register");
        }
    }
}
