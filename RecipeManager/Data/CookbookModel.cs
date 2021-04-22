using Newtonsoft.Json;
using System;

namespace RecipeManager.Data
{
    public class CookbookModel
    {
        [JsonProperty("cookbookId")]
        public Guid CookbookId { get; set; }
        [JsonProperty("userId")]
        public Guid UserId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }
        [JsonProperty("createdOn")]
        public DateTime CreatedOn { get; set; }
        [JsonProperty("modifiedOn")]
        public DateTime ModifiedOn { get; set; }
    }
}
