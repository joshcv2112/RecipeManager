using Newtonsoft.Json;
using System;

namespace RecipeManager.Data
{
    public class CreateCookbookModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        [JsonProperty("userId")]
        // For the moment I am hardcoding this value, later I will make the UI send the Id of the currently logged in user.
        public Guid userId = new Guid("98a0866a-a36e-4038-8f68-6b052418e2fa");
    }
}
 