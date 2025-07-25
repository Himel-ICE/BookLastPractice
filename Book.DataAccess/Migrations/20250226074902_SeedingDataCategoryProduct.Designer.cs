﻿// <auto-generated />
using Book.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Book.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContex))]
    [Migration("20250226074902_SeedingDataCategoryProduct")]
    partial class SeedingDataCategoryProduct
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Book.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            DisplayOrder = 1,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 5,
                            DisplayOrder = 1,
                            Name = "Scifi"
                        },
                        new
                        {
                            Id = 6,
                            DisplayOrder = 1,
                            Name = "History"
                        },
                        new
                        {
                            Id = 20,
                            DisplayOrder = 1,
                            Name = "Drama"
                        },
                        new
                        {
                            Id = 30,
                            DisplayOrder = 1,
                            Name = "World War"
                        },
                        new
                        {
                            Id = 40,
                            DisplayOrder = 1,
                            Name = "Economy"
                        });
                });

            modelBuilder.Entity("Book.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("Price100")
                        .HasColumnType("float");

                    b.Property<double>("Price50")
                        .HasColumnType("float");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "John Doe",
                            CategoryId = 4,
                            Description = "A comprehensive guide to learning C#",
                            ISBN = "978-1-23456-789-0",
                            ImageURL = "",
                            Price = 29.989999999999998,
                            Price100 = 25.989999999999998,
                            Price50 = 27.989999999999998,
                            Title = "C# Fundamentals"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Jane Smith",
                            CategoryId = 6,
                            Description = "Master ASP.NET Core with practical projects",
                            ISBN = "978-1-98765-432-1",
                            ImageURL = "",
                            Price = 39.990000000000002,
                            Price100 = 34.990000000000002,
                            Price50 = 37.990000000000002,
                            Title = "ASP.NET Core Essentials"
                        },
                        new
                        {
                            Id = 11,
                            Author = "John Doe",
                            CategoryId = 20,
                            Description = "A comprehensive guide to learning C#",
                            ISBN = "978-1-23456-789-0",
                            ImageURL = "",
                            Price = 29.989999999999998,
                            Price100 = 25.989999999999998,
                            Price50 = 27.989999999999998,
                            Title = "C# Fundamentals"
                        },
                        new
                        {
                            Id = 12,
                            Author = "Jane Smith",
                            CategoryId = 40,
                            Description = "Master ASP.NET Core with practical projects",
                            ISBN = "978-1-98765-432-1",
                            ImageURL = "",
                            Price = 39.990000000000002,
                            Price100 = 34.990000000000002,
                            Price50 = 37.990000000000002,
                            Title = "ASP.NET Core Essentials"
                        });
                });

            modelBuilder.Entity("Book.Models.Category", b =>
                {
                    b.HasOne("Book.Models.Category", null)
                        .WithMany("Categories")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("Book.Models.Product", b =>
                {
                    b.HasOne("Book.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Book.Models.Category", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
