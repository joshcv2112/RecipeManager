﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RecipeApi.Models;
namespace RecipeApi.Models
{
    public class AppDBContext : DbContext
    {
        private readonly DbContextOptions _options;
        public AppDBContext(DbContextOptions options) : base(options)
        {
            _options = options;
        }

        public DbSet<member> members { get; set; }
        public DbSet<Cookbook> cookbooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}