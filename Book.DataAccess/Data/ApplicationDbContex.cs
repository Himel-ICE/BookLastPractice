using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Book.Models;

namespace Book.DataAccess.Data
{
    public class ApplicationDbContex : DbContext
    {
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 4, Name = "Action", DisplayOrder = 1 },
                new Category { Id = 5, Name = "Scifi", DisplayOrder = 1 },
                new Category { Id = 6, Name = "History", DisplayOrder = 1 },
                new Category { Id = 20, Name = "Drama", DisplayOrder = 1 },
                new Category { Id = 30, Name = "World War", DisplayOrder = 1 },
                new Category { Id = 40, Name = "Economy", DisplayOrder = 1 }
                );
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Title = "C# Fundamentals",
                    Description = "A comprehensive guide to learning C#",
                    ISBN = "978-1-23456-789-0",
                    Author = "John Doe",
                    Price = 29.99,
                    Price50 = 27.99,
                    Price100 = 25.99,
                    CategoryId = 4,
                    ImageURL = ""
                },
                new Product
                {
                    Id = 2,
                    Title = "ASP.NET Core Essentials",
                    Description = "Master ASP.NET Core with practical projects",
                    ISBN = "978-1-98765-432-1",
                    Author = "Jane Smith",
                    Price = 39.99,
                    Price50 = 37.99,
                    Price100 = 34.99,
                    CategoryId = 6,
                    ImageURL = ""
                },
                new Product
                {
                    Id = 11,
                    Title = "C# Fundamentals",
                    Description = "A comprehensive guide to learning C#",
                    ISBN = "978-1-23456-789-0",
                    Author = "John Doe",
                    Price = 29.99,
                    Price50 = 27.99,
                    Price100 = 25.99,
                    CategoryId = 20,
                    ImageURL = ""
                },
                new Product
                {
                    Id = 12,
                    Title = "ASP.NET Core Essentials",
                    Description = "Master ASP.NET Core with practical projects",
                    ISBN = "978-1-98765-432-1",
                    Author = "Jane Smith",
                    Price = 39.99,
                    Price50 = 37.99,
                    Price100 = 34.99,
                    CategoryId = 40,
                    ImageURL = ""
                }
            );
        }
        

    }
}
