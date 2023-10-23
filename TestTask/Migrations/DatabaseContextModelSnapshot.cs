﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestTask.Models;

#nullable disable

namespace TestTask.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestTask.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"));

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            CategoryId = 1,
                            CategoryName = "Books"
                        },
                        new
                        {
                            CategoryId = 2,
                            CategoryName = "Fiction",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            CategoryId = 3,
                            CategoryName = "Non-fiction",
                            ParentCategoryId = 1
                        },
                        new
                        {
                            CategoryId = 4,
                            CategoryName = "Science Fiction",
                            ParentCategoryId = 2
                        },
                        new
                        {
                            CategoryId = 5,
                            CategoryName = "Fantasy",
                            ParentCategoryId = 2
                        },
                        new
                        {
                            CategoryId = 6,
                            CategoryName = "Biography",
                            ParentCategoryId = 3
                        },
                        new
                        {
                            CategoryId = 7,
                            CategoryName = "History",
                            ParentCategoryId = 3
                        },
                        new
                        {
                            CategoryId = 8,
                            CategoryName = "Ancient Rome",
                            ParentCategoryId = 7
                        },
                        new
                        {
                            CategoryId = 9,
                            CategoryName = "Medival Italy",
                            ParentCategoryId = 7
                        });
                });

            modelBuilder.Entity("TestTask.Models.Category", b =>
                {
                    b.HasOne("TestTask.Models.Category", "ParentCategory")
                        .WithMany("SubCategories")
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("TestTask.Models.Category", b =>
                {
                    b.Navigation("SubCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
