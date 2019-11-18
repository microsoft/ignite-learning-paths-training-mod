using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TailwindTraders.Mobile.Models
{
    public class ProductCategoryInfo
    {
        [JsonProperty("brands")]
        public List<Brand> Brands { get; set; }

        [JsonProperty("types")]
        public List<ProductType> Types { get; set; }

        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }
}
