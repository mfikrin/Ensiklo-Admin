using ENSIKLO_ADMIN.Models;
using ENSIKLO_ADMIN.Services;
using ENSIKLO_ADMIN.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ENSIKLO_ADMIN.ViewModels
{
    public class NewCategoryViewModel : BaseViewModel
    {

        public int id_cat;

        public string cat_name;

        private readonly ICatService _catService;

        public NewCategoryViewModel(ICatService catService)
        {
            SaveCommand = new Command(async () => await OnSave(), ValidateSaveCat);
            _catService = catService;
            //SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);

            PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async Task OnSave()
        {
            Debug.WriteLine("tambah cat");

            try
            {
                var cat = new Category
                {

                    Cat_name = Cat_name
                };

                await _catService.AddCatAsync(cat);

                await Shell.Current.GoToAsync("//home");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private bool ValidateSaveCat()
        {
            return !String.IsNullOrWhiteSpace(cat_name);
            //return true;
        }

        public string Cat_name
        {
            get => cat_name;
            set => SetProperty(ref cat_name, value);
        }
    }
}
