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
    public partial class BooksPage : ContentPage
    {
        private readonly BookViewModel _booksViewModel;
        public BooksPage()
        {
            InitializeComponent();
            _booksViewModel = Startup.Resolve<BookViewModel>();
            BindingContext = _booksViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _booksViewModel.OnAppearing();
            _booksViewModel?.PopulateBooks();
        }
    }
}