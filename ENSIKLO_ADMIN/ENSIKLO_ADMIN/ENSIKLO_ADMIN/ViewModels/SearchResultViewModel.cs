using ENSIKLO_ADMIN.Models;
using ENSIKLO_ADMIN.Services;
using ENSIKLO_ADMIN.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ENSIKLO_ADMIN.ViewModels
{
    [QueryProperty(nameof(SearchQuery), nameof(SearchQuery))]
    public class SearchResultViewModel : BaseViewModel
    {
        private Book _selectedBook;

        private ObservableCollection<Book> booksBottom;

        public string search_input;
        public string search_query;

        private readonly IBookService _bookService;
        public Command LoadBooksCommand { get; }
        public Command AddBookCommand { get; }

        public Command RefreshCommand { get; }
        public Command SearchCommand { get; }

        //public Command<Book> BookTapped { get; }

        public SearchResultViewModel(IBookService bookService)
        {
            Title = "Catalog";

            _bookService = bookService;
     
            BooksBottom = new ObservableCollection<Book>();

            RefreshCommand = new Command(onTappedRefresh);
            SearchCommand = new Command(OnSearchClicked);
        }

        public async void PopulateBooks()
        {
            IsBusy = true;
            Debug.WriteLine("POPULATING");

            try
            {
                BooksBottom.Clear();

                var booksBottomTemp = await _bookService.SearchBooks(SearchQuery);
                foreach (var book in booksBottomTemp)
                {
                    BooksBottom.Add(book);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("POPULATING: ERROR");
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedBook = null;
        }

        public ObservableCollection<Book> BooksBottom
        {
            get => booksBottom;
            set
            {
                booksBottom = value;
                OnPropertyChanged(nameof(BooksBottom));
            }
        }

        public string SearchInput
        {
            get => search_input;
            set => SetProperty(ref search_input, value);
        }

        public Book SelectedBook
        {
            get => _selectedBook;
            set
            {
                if (_selectedBook != value)
                {
                    SetProperty(ref _selectedBook, value);
                    OnBookSelected(value);
                }

            }
        }

        public string SearchQuery
        {
            get => search_query;
            set
            {
                search_query = value;
                SearchInput = value;
                PopulateBooks();
            }
        }


        async void OnBookSelected(Book book)
        {
            if (book == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(BookDetailPage)}?{nameof(BookDetailViewModel.BookId)}={book.Id_book}");
            
        }

        private async void onTappedRefresh(object obj)
        {
            OnAppearing();
            PopulateBooks();
        }

        private async void OnSearchClicked()
        {
            //await Shell.Current.Navigation.PopAllPopupAsync();
            await Shell.Current.Navigation.PopAsync();
            await Shell.Current.GoToAsync($"{nameof(SearchResultPage)}?{nameof(SearchResultViewModel.SearchQuery)}={search_input}");
        }
    }
}
