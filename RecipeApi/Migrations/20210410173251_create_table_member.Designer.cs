﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using RecipeApi.Models;

namespace RecipeApi.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210410173251_create_table_member")]
    partial class create_table_member
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RecipeApi.Models.member", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("members");
                });
#pragma warning restore 612, 618
        }
    }
}
