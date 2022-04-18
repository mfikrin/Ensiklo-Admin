using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ENSIKLO_ADMIN.Models
{
    public class Book
    {
        [JsonPropertyName("id_book")]
        public int Id_book { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        [JsonPropertyName("year_published")]
        public DateTime Year_published { get; set; }

        [JsonPropertyName("description_book")]
        public string Description_book { get; set; }

        [JsonPropertyName("book_content")]
        public string Book_content { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("url_cover")]
        public string Url_cover { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("added_time")]
        public DateTime Added_time { get; set; }

        [JsonPropertyName("keywords")]
        public string Keywords { get; set; }

        [JsonPropertyName("isbn")]
        public string Isbn { get; set; }


    }
}
