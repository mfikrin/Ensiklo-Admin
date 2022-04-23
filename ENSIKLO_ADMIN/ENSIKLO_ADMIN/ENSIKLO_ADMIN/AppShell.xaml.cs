using ENSIKLO_ADMIN;
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
            Routing.RegisterRoute(nameof(UpdateBookPage), typeof(UpdateBookPage));
            Routing.RegisterRoute(nameof(SearchResultPage), typeof(SearchResultPage));
            Routing.RegisterRoute(nameof(BooksFromPublisherPage), typeof(BooksFromPublisherPage));
            // Routing.RegisterRoute(nameof(BooksFromAuthorPage), typeof(BooksFromAuhtorPage));

        }

    }
}
