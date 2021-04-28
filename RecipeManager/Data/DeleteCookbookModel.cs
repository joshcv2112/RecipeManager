using Newtonsoft.Json;
using System;

namespace RecipeManager.Data
{
    public class DeleteCookbookModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("cookbookId")]
        public Guid CookbookId { get; set; }
    }
}
