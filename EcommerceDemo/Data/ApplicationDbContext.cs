using System;
using System.Collections.Generic;
using System.Text;
using EcommerceDemo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcommerceDemo.Data
{
	public class ApplicationDbContext : IdentityDbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		public DbSet<Product> ProductItems { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<ShoppingCartItem> CartItems { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderDetail> OrderDetails { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Computer" });
			modelBuilder.Entity<Category>().HasData(new Category { Id = 2, Name = "Mobile" });
			modelBuilder.Entity<Category>().HasData(new Category { Id = 3, Name = "Labtop" });
			modelBuilder.Entity<Category>().HasData(new Category { Id = 4, Name = "Notebook" });
			modelBuilder.Entity<Category>().HasData(new Category { Id = 5, Name = "Game Console" });

			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 1,
				Name = "Computer",
				Price = 1000,
				CategoryId = 1,
				Description = "Windows and Linux",
				ImageUrl = "\\Images\\Computer1.jpg",
				IsInStock = true

			});

			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 2,
				Name = "NoteBook",
				Price = 900,
				CategoryId = 4,
				Description = "Windows and Linux",
				ImageUrl = "\\Images\\Computer2.jpg",
				IsInStock = true

			});
			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 3,
				Name = "Labtop-Assus",
				Price = 1500,
				CategoryId = 3,
				Description = "Windows and Linux",
				ImageUrl = "\\Images\\Computer3.jpg",
				IsInStock = true

			});

			modelBuilder.Entity<Product>().HasData(new Product
			{
				Id = 4,
				Name = "Mobile-samsune 10s",
				Price = 900,
				CategoryId = 2,
				Description = "Android and Apple",
				ImageUrl = "\\Images\\Computer4.jpg",
				IsInStock = true

			});
		}
	}
}
