using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ENSIKLO_ADMIN.Models
{
    public class NumUsers
    {
        [JsonPropertyName("num_users")]
        public int num_users { get; set; }
    }
}
