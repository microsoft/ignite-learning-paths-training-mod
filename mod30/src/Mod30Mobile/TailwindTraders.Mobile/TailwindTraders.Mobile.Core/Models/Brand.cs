using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TailwindTraders.Mobile.Models
{
    public class Brand
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
