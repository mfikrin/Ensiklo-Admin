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
    public partial class NewBookPage : ContentPage
    {
        private readonly NewBookViewModel _newBooksViewModel;
        public NewBookPage()
        {
            InitializeComponent();
            _newBooksViewModel = Startup.Resolve<NewBookViewModel>();
            BindingContext = _newBooksViewModel;
            _newBooksViewModel?.PopulateCat();
        }
    }
}