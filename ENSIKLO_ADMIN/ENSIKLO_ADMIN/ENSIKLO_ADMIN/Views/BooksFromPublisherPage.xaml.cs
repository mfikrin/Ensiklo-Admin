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
    public partial class BooksFromPublisherPage : ContentPage
    {
        private readonly BooksFromPublisherViewModel _booksFromPublisherViewModel;
        public BooksFromPublisherPage()
        {
            InitializeComponent();
            _booksFromPublisherViewModel = Startup.Resolve<BooksFromPublisherViewModel>();
            BindingContext = _booksFromPublisherViewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _booksFromPublisherViewModel.OnAppearing();
            _booksFromPublisherViewModel?.PopulateBooks();
        }
    }
}