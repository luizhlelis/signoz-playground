using System;
using Microsoft.EntityFrameworkCore;
using Order.Api.Model;

namespace Order.Api.Infrastructure
{
    public class OrderContext : DbContext
    {
        public DbSet<Model.Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Seed(modelBuilder);
        }

        private static void Seed(ModelBuilder modelBuilder)
        {
            var products = new Product[]
            {
                new Product(Guid.Parse("9a2a5528-b9e5-4aa6-add7-ae837c45c123"), 15, "Basic T-Shirt"),
                new Product(Guid.Parse("e4b92f2a-fb8a-40b3-87c1-7c85e15aa1f4"), 25, "Jeans")
            }; 
            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}