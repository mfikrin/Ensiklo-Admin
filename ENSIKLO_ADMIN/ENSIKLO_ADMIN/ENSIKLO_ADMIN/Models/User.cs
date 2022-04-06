using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ENSIKLO_ADMIN.Models
{
    public class User
    {
        [JsonPropertyName("id_user")]
        public int Id_user { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("role")]
        public string Role { get; set; }

    }
}
