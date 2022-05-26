using ENSIKLO_ADMIN.Models;
using ENSIKLO_ADMIN.Services;
using ENSIKLO_ADMIN.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ENSIKLO_ADMIN.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        private readonly IAdminService _userService;
        public Command LogoutCommand { get; }
        public string email;
        public string userName;
        public Int64 id;

        public Command UpdateProfile { get; }

        public ProfileViewModel(IAdminService userService)
        {

            _userService = userService;

            LogoutCommand = new Command(OnClickLogout);
            // UpdateProfile = new Command(UpdateProfileTapped);

        }

        private async void OnClickLogout(object obj)
        {
            await Shell.Current.GoToAsync($"//login");
        }

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string Name
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public async void GetData()
        {
            email = CurrentUser.Email;
            userName = CurrentUser.Username;
            id = CurrentUser.Id;
  
            Email = email;
            Name = userName;
        }

        // private async void UpdateProfileTapped(object obj)
        // {
        //     await Shell.Current.GoToAsync(nameof(UpdateProfilePage));
        // }
    }
}
