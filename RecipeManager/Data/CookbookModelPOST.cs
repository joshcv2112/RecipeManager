using Newtonsoft.Json;
using System;

namespace RecipeManager.Data
{
    public class CookbookModelPOST
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
    }
}
