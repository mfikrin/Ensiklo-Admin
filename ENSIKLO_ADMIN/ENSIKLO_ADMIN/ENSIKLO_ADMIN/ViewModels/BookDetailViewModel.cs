using Acr.UserDialogs;
using ENSIKLO_ADMIN.Models;
using ENSIKLO_ADMIN.Services;
using ENSIKLO_ADMIN.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;
using Windows.UI.Popups;
using Xamarin.Forms;

namespace ENSIKLO_ADMIN.ViewModels
{
    [QueryProperty(nameof(BookId), nameof(BookId))]
    public class BookDetailViewModel : BaseViewModel
    {
    
        private string id_book ;

        private string title ;

        private string author ;

        private string publisher ;

        private DateTime year_published ;

        private string description_book ;

        private string book_content ;

        private string url_cover ;

        private string category ;

        private string keywords ;

        private readonly IBookService _bookService;
        public Command DeleteBookCommand { get; }
        public Command TappedCommand { get; }
        public Command PublisherTappedCommand { get; }
        public Command AuthorTappedCommand { get; }

        public UICommandInvokedHandler DeleteBookHandler { get; }
      
        public BookDetailViewModel(IBookService bookService)
        {
            _bookService = bookService;

            DeleteBookCommand = new Command(async bookid => await OnDeleteBook(bookid: BookId));

            //DeleteBookCommand = new Command(async () => await OnDeleteBook());

            TappedCommand = new Command(async bookid => await UpdateBookTapped(book_id: int.Parse(BookId)));

            PublisherTappedCommand = new Command(async publishername => await onPublisherTapped(publisher_name: Publisher));
            AuthorTappedCommand = new Command(async authorname => await onAuthorTapped(author_name: Author));

            DeleteBookHandler = new UICommandInvokedHandler(async (cmd) =>
            {
                if (cmd.Label == "Yes")
                {
                    await _bookService.DeleteItemAsync(int.Parse(BookId));
                    await Shell.Current.GoToAsync(nameof(BooksPage));
                }
                else
                {
                    Debug.WriteLine("No");
                }
            });
        }

        private async Task onPublisherTapped(string publisher_name)
        {
            //await Shell.Current.GoToAsync(nameof(BooksFromPublisherPage));
            await Shell.Current.GoToAsync($"{nameof(BooksFromPublisherPage)}?{nameof(BooksFromPublisherViewModel.PublisherName)}={publisher_name}");
        }

        private async Task onAuthorTapped(string author_name)
        {
            await Shell.Current.GoToAsync($"{nameof(BooksFromAuthorPage)}?{nameof(BooksFromAuthorViewModel.AuthorName)}={author_name}");
        }


        public int Id { get; set; }
        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public string Author
        {
            get => author;
            set => SetProperty(ref author, value);
        }

        public string Publisher
        {
            get => publisher;
            set => SetProperty(ref publisher, value);
        }

        public DateTime Year_published
        {
            get => year_published;
            set => SetProperty(ref year_published, value);
        }

        public string Description_book
        {
            get => description_book;
            set => SetProperty(ref description_book, value);
        }

        public string Book_content
        {
            get => book_content;
            set => SetProperty(ref book_content, value);
        }

        public string Url_cover
        {
            get => url_cover;
            set => SetProperty(ref url_cover, value);
        }

        public string Category
        {
            get => category;
            set => SetProperty(ref category, value);
        }

        public string Keywords
        {
            get => keywords;
            set => SetProperty(ref keywords, value);
        }


        public string BookId
        {
            get => id_book;
            set
            {
                id_book = value;
                LoadBookId(id_book);
                
            }
        }

        public async void LoadBookId(string bookId)
        {
            try
            {
                var book = await _bookService.GetItemAsync(int.Parse(bookId));
                Debug.WriteLine("Pass in hereeeeeeeeee");
                if (bookId != null)
                {
                    Id = book.Id_book;
                    Title = book.Title;
                    Author = book.Author;
                    Publisher = book.Publisher;
                    Year_published = book.Year_published;
                    Description_book = book.Description_book;
                    Book_content = book.Book_content;
                    Url_cover = book.Url_cover;
                    Category = book.Category;
                    Keywords = book.Keywords;
                }
                  
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to Load Item");
                Debug.WriteLine(ex.Message);
            }
        }

        private async Task OnDeleteBook(string bookid)
        {
            Debug.WriteLine("On delete Book");
            Debug.WriteLine(bookid);
            //var result = await UserDialogs.Instance.ConfirmAsync("Are you sure to delete this book ?", "Confirm Selection", "Yes", "No");

            //Debug.WriteLine(result);
            //if (result == 1)
            //{
            //    await _bookService.DeleteItemAsync(int.Parse(bookid));
            //    await Shell.Current.GoToAsync(nameof(BooksPage));
            //}

            //TODO: Add confirmation Before Delete

            try
            {

                
               // confirmation before delete message dialog
                var dialog = new MessageDialog( "Are you sure to delete this book ?", "Confirm Selection");
                dialog.Commands.Add(new UICommand("Yes", new UICommandInvokedHandler(DeleteBookHandler)));
                dialog.Commands.Add(new UICommand("No", new UICommandInvokedHandler(DeleteBookHandler)));
                dialog.ShowAsync();        
            }



                // await _bookService.DeleteItemAsync(int.Parse(bookid));

                // // var title = "Removed Book";
                // // var content = "Are you sure to delete this book ?";

                // // var yesCommand = new UICommand("Yes");
                // // var noCommand = new UICommand("No");
               

                // // var dialog = new MessageDialog(content, title);
                // // dialog.Options = MessageDialogOptions.None;
                // // dialog.Commands.Add(yesCommand);

                // // dialog.DefaultCommandIndex = 0;
                // // dialog.CancelCommandIndex = 0;

                // // if (noCommand != null)
                // // {
                // //     dialog.Commands.Add(noCommand);
                // //     dialog.CancelCommandIndex = (uint)dialog.Commands.Count - 1;
                // // }


                // // var command = await dialog.ShowAsync();

          
                // // if (command == yesCommand)
                // // {
                // //     // handle yes command
                // // }
                // // else if (command == noCommand)
                // // {
                // //     // handle no command
                // // }
             

                // // await App.Current.MainPage.DisplayAlert("Removed Book", "The book has been removed", "OK");

                // await Shell.Current.GoToAsync(nameof(BooksPage));
            //}
            catch (Exception ex)
            {

                Debug.WriteLine("Book in library user");
                Debug.WriteLine(ex.Message);
            }
            

            



        }

        //private async Task OnDeleteBook()
        //{
        //    var result = await UserDialogs.Instance.ConfirmAsync("Are you sure to delete this book ?", "Confirm Selection", "Yes", "No");
        //    Debug.WriteLine(result);
        //}

        private async Task UpdateBookTapped(int book_id)
        {
            await Shell.Current.GoToAsync($"{nameof(UpdateBookPage)}?{nameof(UpdateBookViewModel.BookId)}={book_id}");
        }




    }
}
