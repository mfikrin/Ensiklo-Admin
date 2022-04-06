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
    public partial class BookDetailPage : ContentPage
    {
        public BookDetailPage()
        {
            InitializeComponent();
            BindingContext = Startup.Resolve<BookDetailViewModel>();
        }
    }
}