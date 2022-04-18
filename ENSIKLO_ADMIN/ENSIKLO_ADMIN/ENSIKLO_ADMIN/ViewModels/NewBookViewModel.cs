using ENSIKLO_ADMIN.Models;
using ENSIKLO_ADMIN.Services;
using ENSIKLO_ADMIN.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ENSIKLO_ADMIN.ViewModels
{
    public class NewBookViewModel : BaseViewModel
    {
        public int id_book;

        public string title;

        public string author;

        public string publisher;

        public int year;

        public int month;

        public int day;

        public DateTime year_published;

        public string description_book;

        public string book_content;

        public int page;

        public string url_cover;

        public string category;

        public DateTime added_time;

        public string keywords;

        public string isbn;

        private readonly IBookService _bookService;

        private readonly ICatService _catService;

        private ObservableCollection<String> categories;

        public NewBookViewModel(IBookService bookService, ICatService catService)
        {
            _bookService = bookService;
            _catService = catService;
            Categories = new ObservableCollection<String>();
            SaveCommand = new Command(async () => await OnSave(), ValidateSave);
            CancelCommand = new Command(OnCancel);
            NewCatCommand = new Command(OnNewCat);
            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        public ObservableCollection<String> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(title)
                && !String.IsNullOrWhiteSpace(author)
                && !String.IsNullOrWhiteSpace(publisher)
                && !String.IsNullOrWhiteSpace(year_published.ToString())
                && !String.IsNullOrWhiteSpace(description_book)
                && !String.IsNullOrWhiteSpace(book_content)
                && !String.IsNullOrWhiteSpace(page.ToString())
                && !String.IsNullOrWhiteSpace(url_cover)
                && !String.IsNullOrWhiteSpace(category)
                && !String.IsNullOrWhiteSpace(keywords)
                ;
            //isbn kalo ga ada gausah diisi gapapa
            //return true;
        }

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

        public int Year
        {
            get => year;
            set => SetProperty(ref year, value);
        }

        public int Month
        {
            get => month;
            set => SetProperty(ref month, value);
        }

        public int Day
        {
            get => day;
            set => SetProperty(ref day, value);
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
        public int Page
        {
            get => page;
            set => SetProperty(ref page, value);
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

        public DateTime Added_time
        {
            get => added_time;
            set => SetProperty(ref added_time, value);
        }

        public string Keywords
        {
            get => keywords;
            set => SetProperty(ref keywords, value);
        }

        public string Isbn
        {
            get => isbn;
            set => SetProperty(ref isbn, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }
        public Command NewCatCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("//admin/homeAdmin");
        }

        private async void OnNewCat()
        {
            await Shell.Current.GoToAsync(nameof(NewCategoryPage));
        }

        

        public async void PopulateCat()
        {
            try
            {
                Categories.Clear();

                var cats = await _catService.GetCatsAsync();
                foreach (var cat in cats)
                {
                    Categories.Add(cat.Cat_name);
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private async Task OnSave()
        {
            try
            {
                //YYYY.MM,DD
                year_published = new DateTime(Year, Month, Day);
                Debug.WriteLine(year_published);
                added_time = DateTime.Now;
                Debug.WriteLine(added_time);
                var book = new Book
                {

                    Title = Title,
                    Author = Author,
                    Publisher = Publisher,
                    Year_published = Year_published,
                    Description_book = Description_book,
                    Book_content = Book_content,
                    Page = Page,
                    Url_cover = Url_cover,
                    Category = Category,
                    Added_time = Added_time,
                    Keywords = Keywords,
                    Isbn = Isbn
                };

                await _bookService.AddItemAsync(book);

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}