using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeManager.Pages
{
    public class CookbookItem
    {
        [Required]
        public string CookbookTitle { get; set; }
        [Required]
        [StringLength(500, ErrorMessage = "Description exceeded max length")]
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
