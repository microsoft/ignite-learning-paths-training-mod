using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TailwindTraders.Mobile.Models
{
    public class ProductType
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
