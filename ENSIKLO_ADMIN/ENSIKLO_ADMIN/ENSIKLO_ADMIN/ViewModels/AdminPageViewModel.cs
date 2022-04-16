using ENSIKLO_ADMIN.Services;
using ENSIKLO_ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using Xamarin.Forms;
using ENSIKLO_ADMIN.Views;

namespace ENSIKLO_ADMIN.ViewModels
{
    public class AdminPageViewModel : BaseViewModel
    {
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        public int userTotal;
        public int bookTotal;


        public AdminPageViewModel(IUserService userService, IBookService bookService)
        {
            _userService = userService;
            _bookService = bookService;
            NewCatCommand = new Command(OnNewCat);
            NewBookCommand = new Command(OnBookCat);
        }

        public async void GetDatas()
        {
            userTotal = 0;
            bookTotal = 0;
            //var user = await _userService.GetUsersAsync();
            //foreach (var item in user)
            //{
            //    userTotal += 1;
            //}
            var books = await _bookService.GetItemsAsync();
            foreach (var book in books)
            {
                bookTotal += 1;
            }
            Debug.WriteLine(bookTotal);
            Debug.WriteLine(userTotal);
            BookTotal = bookTotal;
            UserTotal = userTotal;

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
