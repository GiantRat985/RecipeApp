﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RecipeApp;

#nullable disable

namespace RecipeApp.Migrations
{
    [DbContext(typeof(RecipeAppDbContext))]
    partial class RecipeAppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("RecipeApp.RecipeData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<string>("HtmlContent")
                        .HasColumnType("TEXT");

                    b.Property<string>("WebsiteUrl")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.ToTable("RecipeSet");
                });
#pragma warning restore 612, 618
        }
    }
}
