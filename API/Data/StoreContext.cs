using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace API.Data;

public class StoreContext : DbContext
{
    public StoreContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Product>()
            .HasData(new Product
            {
                Id = 1, // Set a non-zero value for the Id
                Name = "Laptop",
                Description = "High-performance laptop with the latest technology",
                Price = 1500,
                PictureUrl = "http://picsum.photos/200",
                Type = "Electronics",
                Brand = "ExampleBrand",
                QuantityInStock = 50,
                PublicId = "Test"
            },
            new Product
            {
                Id = 2, // Set a non-zero value for the Id
                Name = "Smartphone",
                Description = "Feature-packed smartphone with advanced camera",
                Price = 800,
                PictureUrl = "http://picsum.photos/200",
                Type = "Electronics",
                Brand = "ExampleBrand",
                QuantityInStock = 100,
                PublicId = "Test"
            },
            new Product
            {
                Id = 3, // Set a non-zero value for the Id
                Name = "Headphones",
                Description = "High-quality headphones with noise-cancellation",
                Price = 200,
                PictureUrl = "http://picsum.photos/200",
                Type = "Electronics",
                Brand = "ExampleBrand",
                QuantityInStock = 30,
                PublicId = "Test"
            }
            );
    }

}