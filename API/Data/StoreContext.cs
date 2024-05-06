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
            },
            new Product
            {
                Id = 4,
                Name = "Laptop",
                Description = "High-performance laptop with SSD storage",
                Price = 120000, // Price in cents/pennies
                PictureUrl = "http://picsum.photos/200?id=1",
                Type = "Electronics",
                Brand = "Dell",
                QuantityInStock = 50,
                PublicId = "laptop_1"
            },
    new Product
    {
        Id = 5,
        Name = "Smartphone",
        Description = "Latest smartphone with OLED display",
        Price = 80000,
        PictureUrl = "http://picsum.photos/200?id=2",
        Type = "Electronics",
        Brand = "Samsung",
        QuantityInStock = 100,
        PublicId = "smartphone_1"
    },
    new Product
    {
        Id = 6,
        Name = "Headphones",
        Description = "Wireless headphones with noise cancellation",
        Price = 30000,
        PictureUrl = "http://picsum.photos/200?id=3",
        Type = "Electronics",
        Brand = "Sony",
        QuantityInStock = 75,
        PublicId = "headphones_1"
    },
    new Product
    {
        Id = 7,
        Name = "T-shirt",
        Description = "Comfortable cotton t-shirt",
        Price = 2000,
        PictureUrl = "http://picsum.photos/200?id=4",
        Type = "Clothing",
        Brand = "Nike",
        QuantityInStock = 200,
        PublicId = "tshirt_1"
    },
    new Product
    {
        Id = 8,
        Name = "Coffee Maker",
        Description = "Automatic coffee maker with grinder",
        Price = 50000,
        PictureUrl = "http://picsum.photos/200?id=5",
        Type = "Kitchen Appliances",
        Brand = "Breville",
        QuantityInStock = 30,
        PublicId = "coffeemaker_1"
    },
    new Product
    {
        Id = 9,
        Name = "Backpack",
        Description = "Durable backpack for outdoor activities",
        Price = 6000,
        PictureUrl = "http://picsum.photos/200?id=6",
        Type = "Accessories",
        Brand = "The North Face",
        QuantityInStock = 80,
        PublicId = "backpack_1"
    },
    new Product
    {
        Id = 10,
        Name = "Sneakers",
        Description = "Stylish sneakers for everyday wear",
        Price = 4000,
        PictureUrl = "http://picsum.photos/200?id=7",
        Type = "Footwear",
        Brand = "Adidas",
        QuantityInStock = 150,
        PublicId = "sneakers_1"
    },
    new Product
    {
        Id = 11,
        Name = "Watch",
        Description = "Elegant wristwatch with leather strap",
        Price = 25000,
        PictureUrl = "http://picsum.photos/200?id=8",
        Type = "Accessories",
        Brand = "Rolex",
        QuantityInStock = 50,
        PublicId = "watch_1"
    },
    new Product
    {
        Id = 12,
        Name = "Wireless Mouse",
        Description = "Ergonomic wireless mouse for desktop use",
        Price = 5000,
        PictureUrl = "http://picsum.photos/200?id=9",
        Type = "Electronics",
        Brand = "Logitech",
        QuantityInStock = 100,
        PublicId = "mouse_1"
    },
    new Product
    {
        Id = 13,
        Name = "Yoga Mat",
        Description = "Non-slip yoga mat for home workouts",
        Price = 3000,
        PictureUrl = "http://picsum.photos/200?id=10",
        Type = "Fitness",
        Brand = "Lululemon",
        QuantityInStock = 120,
        PublicId = "yogamat_1"
    }
            );
    }

}