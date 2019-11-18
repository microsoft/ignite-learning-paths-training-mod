using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TailwindTraders.Mobile.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("price")]
        public long Price { get; set; }

        [JsonProperty("imageUrl")]
        public Uri ImageUrl { get; set; }

        public string Image { get => ImageUrl.ToString(); }

        [JsonProperty("brand")]
        public Brand Brand { get; set; }

        [JsonProperty("type")]
        public ProductType Type { get; set; }

        [JsonProperty("features")]
        public object Features { get; set; }

        [JsonProperty("stockUnits")]
        public long StockUnits { get; set; }
    }
}
