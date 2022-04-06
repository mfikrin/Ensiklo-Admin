using ENSIKLO_ADMIN.ViewModels;
using ENSIKLO_ADMIN.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ENSIKLO_ADMIN
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(BookDetailPage), typeof(BookDetailPage));
            Routing.RegisterRoute(nameof(NewBookPage), typeof(NewBookPage));
            Routing.RegisterRoute(nameof(BooksPage), typeof(BooksPage));
            Routing.RegisterRoute(nameof(NewCategoryPage), typeof(NewCategoryPage));
        }

    }
}
