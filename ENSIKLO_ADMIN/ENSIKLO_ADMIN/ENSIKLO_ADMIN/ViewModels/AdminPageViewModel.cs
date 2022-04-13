using ENSIKLO_ADMIN.Services;
using ENSIKLO_ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Xamarin.Forms;
using ENSIKLO_ADMIN.Views;
using System.Linq;

namespace ENSIKLO_ADMIN.ViewModels
{
    public class AdminPageViewModel : BaseViewModel
    {
        private readonly IAdminService _adminService;
        private readonly IBookService _bookService;
        private readonly ICatService _catService;
        public int userTotal;
        public int bookTotal;
        public int categoryTotal;


        public AdminPageViewModel(IAdminService adminService, IBookService bookService, ICatService catService)
        {
            _adminService = adminService;
            _bookService = bookService;
            _catService = catService;
            NewCatCommand = new Command(OnNewCat);
            NewBookCommand = new Command(OnBookCat);
        }

        public async void GetDatas()
        {
            userTotal = 0;
            bookTotal = 0;
            categoryTotal = 0;
            //BLOM ADA GETUSERSASYNC PLS HELP
            //var user = await _userService.GetUsersAsync();
            //foreach (var item in user)
            //{
            //    userTotal += 1;
            //}
            var books = await _bookService.GetItemsAsync();
            var categories = await _catService.GetCatsAsync();

            bookTotal = books.Count();
            categoryTotal = categories.Count();

            Debug.WriteLine(bookTotal);
            Debug.WriteLine(userTotal);
            BookTotal = bookTotal;
            UserTotal = userTotal;
            CategoryTotal = categoryTotal;

        }


        public int UserTotal
        {
            get => userTotal;
            set
            {
                userTotal = value;
                OnPropertyChanged(nameof(UserTotal));
            }
        }

        public int BookTotal
        {
            get => bookTotal;
            set
            {
                bookTotal = value;
                OnPropertyChanged(nameof(BookTotal));
            }
        }

        public int CategoryTotal
        {
            get => categoryTotal;
            set
            {
                categoryTotal = value;
                OnPropertyChanged(nameof(CategoryTotal));
            }
        }
        public Command NewCatCommand { get; }

        private async void OnNewCat()
        {
            await Shell.Current.GoToAsync(nameof(NewCategoryPage));
        }

        public Command NewBookCommand { get; }

        private async void OnBookCat()
        {
            await Shell.Current.GoToAsync(nameof(NewBookPage));
        }




    }

}
