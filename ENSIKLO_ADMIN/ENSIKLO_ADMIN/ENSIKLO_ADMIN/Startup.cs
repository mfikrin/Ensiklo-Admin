
using Microsoft.Extensions.DependencyInjection;
using System;
using ENSIKLO_ADMIN.Services;
using ENSIKLO_ADMIN.ViewModels;

namespace ENSIKLO_ADMIN
{
    public static class Startup
    {
        private static IServiceProvider serviceProvider;
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            //add services

            //services.AddSingleton<IBookService, DummyBookStore>();
            //services.AddSingleton<IUserService, DummyUser>();
            //services.AddSingleton<ICatService, DummyCategory>();

            services.AddHttpClient<IBookService, APIBookService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:49067/api/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient<ICatService, APICatService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:49067/api/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            services.AddHttpClient<IAdminService, APIAdminService>(client =>
            {
                client.BaseAddress = new Uri("http://localhost:49067/api/");
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });


            //add viewmodels
            services.AddTransient<BookViewModel>();
            services.AddTransient<NewBookViewModel>();
            services.AddTransient<BookDetailViewModel>();
            services.AddTransient<RegisterViewModel>();
            services.AddTransient<LoginViewModel>();
            services.AddTransient<ProfileViewModel>();
            services.AddTransient<NewCategoryViewModel>();
            services.AddTransient<AdminPageViewModel>();
            services.AddTransient<UpdateBookViewModel>();
            services.AddTransient<BooksFromPublisherViewModel>();
            services.AddTransient<BooksFromAuthorViewModel>();

            services.AddTransient<SearchResultViewModel>();
            
            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
