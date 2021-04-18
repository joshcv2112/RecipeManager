using Newtonsoft.Json;
using System.Collections.Generic;

namespace RecipeManager.Data
{
    public class Response
    {
        [JsonProperty("data")]
        public List<CookbookModel> Cookbooks { get; set; }
    }
}
