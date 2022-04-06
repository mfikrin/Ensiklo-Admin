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
    public class APICatService : ICatService
    {

        private readonly HttpClient _httpClient;

        public APICatService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> AddCatAsync(Category item)
        {
            var response = await _httpClient.PostAsync("Cat",
                new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }

        public async Task<Category> GetCatAsync(int id)
        {
            var response = await _httpClient.GetAsync($"Cat/{id}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            //Debug.WriteLine(responseAsString);

            var removeSqrBracket = responseAsString.Substring(1, responseAsString.Length - 2);

            //Debug.WriteLine(removeSqrBracket);

            //responseAsString = @"{""id_book"":1,""title"":""test judul"",""author"":""siapa"",""publisher"":""Gra"",""year_published"":""2001"",""description_book"":""bagus bgt lho"",""book_content"":""https://www.google.com"",""url_cover"":""https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg"",""category"":""science"",""keywords"":""science, nature""}";
            return JsonSerializer.Deserialize<Category>(removeSqrBracket);
        }

        public async Task<IEnumerable<Category>> GetCatsAsync(bool forceRefresh = false)
        {
            var response = await _httpClient.GetAsync("Cat");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Category>>(responseAsString);
        }
    }
}
