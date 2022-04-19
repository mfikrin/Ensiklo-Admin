using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace ENSIKLO_ADMIN.Models
{
    public class NumAdmins
    {
        [JsonPropertyName("num_admin")]
        public int num_admin { get; set; }
    }
}
