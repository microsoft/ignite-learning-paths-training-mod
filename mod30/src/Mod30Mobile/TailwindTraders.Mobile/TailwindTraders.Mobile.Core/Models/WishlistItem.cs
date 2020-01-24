using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TailwindTraders.Mobile.Models
{
    public class WishlistItem
    {
        [JsonProperty("Description")]
        public string Description { get; set; }
        [JsonProperty("Thumbnail")]
        public string ThumbnailImageUrl { get; set; }
        [JsonProperty("Full")]
        public string FullImageUrl { get; set; }
    }
}
