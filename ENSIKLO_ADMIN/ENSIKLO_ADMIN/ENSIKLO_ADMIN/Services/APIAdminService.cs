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
    public class APIAdminService : IAdminService
    {
        private readonly HttpClient _httpClient;

        public APIAdminService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> AddAdminAsync(Admin item)
        {
            var response = await _httpClient.PostAsync("Admin/register",
            new StringContent(JsonSerializer.Serialize(item), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            return await Task.FromResult(true);
        }

        public Task<bool> DeleteAdminAsync(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<Admin> GetAdminAsync(long id)
        {
            var response = await _httpClient.GetAsync($"Admin/getAdmin/{id}");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            //Debug.WriteLine(responseAsString);

            var removeSqrBracket = responseAsString.Substring(1, responseAsString.Length - 2);

            //Debug.WriteLine(removeSqrBracket);

            //responseAsString = @"{""id_book"":1,""title"":""test judul"",""author"":""siapa"",""publisher"":""Gra"",""year_published"":""2001"",""description_book"":""bagus bgt lho"",""book_content"":""https://www.google.com"",""url_cover"":""https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg"",""category"":""science"",""keywords"":""science, nature""}";
            return JsonSerializer.Deserialize<Admin>(removeSqrBracket);
        }

        public Task<IEnumerable<Admin>> GetAdminsAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        public async Task<Admin> GetCurrentAdmin()
        {
            var response = await _httpClient.GetAsync($"Admin/currentAdmin");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            //Debug.WriteLine(responseAsString);

            var removeSqrBracket = responseAsString.Substring(1, responseAsString.Length - 2);

            //Debug.WriteLine(removeSqrBracket);

            //responseAsString = @"{""id_book"":1,""title"":""test judul"",""author"":""siapa"",""publisher"":""Gra"",""year_published"":""2001"",""description_book"":""bagus bgt lho"",""book_content"":""https://www.google.com"",""url_cover"":""https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg"",""category"":""science"",""keywords"":""science, nature""}";
            return JsonSerializer.Deserialize<Admin>(removeSqrBracket);
        }

        public Task<NumAdmins> GetNumAdminsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<NumUsers> GetNumUsersAsync()
        {
            var response = await _httpClient.GetAsync($"Admin/GetTotalUser");

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseAsString);

            var removeSqrBracket = responseAsString.Substring(1, responseAsString.Length - 2);

            Debug.WriteLine(removeSqrBracket);

            //responseAsString = @"{""id_book"":1,""title"":""test judul"",""author"":""siapa"",""publisher"":""Gra"",""year_published"":""2001"",""description_book"":""bagus bgt lho"",""book_content"":""https://www.google.com"",""url_cover"":""https://res.cloudinary.com/ensiklo/image/upload/v1645609810/samples/compact_cover_book_xjkzwq.jpg"",""category"":""science"",""keywords"":""science, nature""}";
            return JsonSerializer.Deserialize<NumUsers>(removeSqrBracket);
        }

        public async Task<string> LoginAdminAsync(LoginRequest loginRequest)
        {
            var response = await _httpClient.PostAsync("Admin/login",
            new StringContent(JsonSerializer.Serialize(loginRequest), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();

            return responseAsString;
        }

        public Task<bool> UpdateAdminAsync(Admin item)
        {
            throw new NotImplementedException();
        }
    }
}
