using ENSIKLO_ADMIN.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ENSIKLO_ADMIN.Services
{
    public class APIBookService : IBookService
    {

        private readonly HttpClient _httpClient;

        public APIBookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddItemAsync(Book item)
        {
            var response = await _httpClient.PostAsync("Book",
                new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Book/{id}");

            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }

        public async Task<Book> GetItemAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Book/{id}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            //Debug.WriteLine(responseAsString);

            var removeSqrBracket = responseAsString.Substring(1, responseAsString.Length - 2);

            //Debug.WriteLine(removeSqrBracket);

            //responseAsString = @"{""id_book"":1,""title"":""test judul"",""author"":""siapa"",""publisher"":""Gra"",""year_published"":""2001"",""description_book"":""bagus bgt lho"",""book_content"":""https://www.google.com"",""url_cover"":""https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg"",""category"":""science"",""keywords"":""science, nature""}";
            return JsonSerializer.Deserialize<Book>(removeSqrBracket);
        }

        public async Task<IEnumerable<Book>> GetItemsAsync(bool forceRefresh = false)
        {
            var response = await _httpClient.GetAsync("Book");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Book>>(responseAsString);
        }

        public async Task<bool> UpdateItemAsync(Book item)
        {
            var response = await _httpClient.PutAsync($"Book/updateBook/{item.Id_book}",
                new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Book>> SearchBooks(string query)
        {
            var response = await _httpClient.GetAsync($"Book/search?title={query}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<IEnumerable<Book>>(responseAsString);
        }

        public async Task<IEnumerable<Book>> GetByPublisher(string query)
        {
            var response = await _httpClient.GetAsync($"Book/GetByPublisher?publisher={query}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Book>>(responseAsString);
        }
    }
}
