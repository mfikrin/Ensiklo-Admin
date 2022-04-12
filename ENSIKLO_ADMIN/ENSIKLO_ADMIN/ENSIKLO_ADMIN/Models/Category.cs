using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ENSIKLO_ADMIN.Models
{
    public class Category
    {
        [JsonPropertyName("id_cat")]
        public int Id_cat { get; set; }

        [JsonPropertyName("cat_name")]
        public string Cat_name { get; set; }

    }
}
