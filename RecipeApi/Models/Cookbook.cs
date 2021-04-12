using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeApi.Models
{
    [Index(nameof(CookbookId), IsUnique = true)]
    public class Cookbook
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CookbookId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public Guid UserId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        public string ImageUrl { get; set; }

        [Column(TypeName = "tinyint")]
        public bool IsActive { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreatedOn { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime ModifiedOn { get; set; }
    }
}