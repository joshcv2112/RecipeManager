using Microsoft.EntityFrameworkCore;

namespace RecipeApi.Models
{
    public class AppDBContext : DbContext
    {
        private readonly DbContextOptions _options;
        public AppDBContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        public DbSet<Cookbook> cookbooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cookbook>()
            .HasIndex(p => new { p.CookbookId })
            .IsUnique(true);

            base.OnModelCreating(modelBuilder);
        }

    }
}