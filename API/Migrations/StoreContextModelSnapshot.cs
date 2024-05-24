﻿// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(StoreContext))]
    partial class StoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("API.Entities.Basket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BuyerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientSecret")
                        .HasColumnType("TEXT");

                    b.Property<string>("PaymentIntentId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("API.Entities.BasketItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BasketId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketItems");
                });

            modelBuilder.Entity("API.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Brand")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .HasColumnType("TEXT");

                    b.Property<long>("Price")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<int>("QuantityInStock")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "ExampleBrand",
                            Description = "High-performance laptop with the latest technology",
                            Name = "Laptop",
                            PictureUrl = "http://picsum.photos/200",
                            Price = 1500L,
                            PublicId = "Test",
                            QuantityInStock = 50,
                            Type = "Electronics"
                        },
                        new
                        {
                            Id = 2,
                            Brand = "ExampleBrand",
                            Description = "Feature-packed smartphone with advanced camera",
                            Name = "Smartphone",
                            PictureUrl = "http://picsum.photos/200",
                            Price = 800L,
                            PublicId = "Test",
                            QuantityInStock = 100,
                            Type = "Electronics"
                        },
                        new
                        {
                            Id = 3,
                            Brand = "ExampleBrand",
                            Description = "High-quality headphones with noise-cancellation",
                            Name = "Headphones",
                            PictureUrl = "http://picsum.photos/200",
                            Price = 200L,
                            PublicId = "Test",
                            QuantityInStock = 30,
                            Type = "Electronics"
                        },
                        new
                        {
                            Id = 4,
                            Brand = "Dell",
                            Description = "High-performance laptop with SSD storage",
                            Name = "Laptop",
                            PictureUrl = "http://picsum.photos/200?id=1",
                            Price = 120000L,
                            PublicId = "laptop_1",
                            QuantityInStock = 50,
                            Type = "Electronics"
                        },
                        new
                        {
                            Id = 5,
                            Brand = "Samsung",
                            Description = "Latest smartphone with OLED display",
                            Name = "Smartphone",
                            PictureUrl = "http://picsum.photos/200?id=2",
                            Price = 80000L,
                            PublicId = "smartphone_1",
                            QuantityInStock = 100,
                            Type = "Electronics"
                        },
                        new
                        {
                            Id = 6,
                            Brand = "Sony",
                            Description = "Wireless headphones with noise cancellation",
                            Name = "Headphones",
                            PictureUrl = "http://picsum.photos/200?id=3",
                            Price = 30000L,
                            PublicId = "headphones_1",
                            QuantityInStock = 75,
                            Type = "Electronics"
                        },
                        new
                        {
                            Id = 7,
                            Brand = "Nike",
                            Description = "Comfortable cotton t-shirt",
                            Name = "T-shirt",
                            PictureUrl = "http://picsum.photos/200?id=4",
                            Price = 2000L,
                            PublicId = "tshirt_1",
                            QuantityInStock = 200,
                            Type = "Clothing"
                        },
                        new
                        {
                            Id = 8,
                            Brand = "Breville",
                            Description = "Automatic coffee maker with grinder",
                            Name = "Coffee Maker",
                            PictureUrl = "http://picsum.photos/200?id=5",
                            Price = 50000L,
                            PublicId = "coffeemaker_1",
                            QuantityInStock = 30,
                            Type = "Kitchen Appliances"
                        },
                        new
                        {
                            Id = 9,
                            Brand = "The North Face",
                            Description = "Durable backpack for outdoor activities",
                            Name = "Backpack",
                            PictureUrl = "http://picsum.photos/200?id=6",
                            Price = 6000L,
                            PublicId = "backpack_1",
                            QuantityInStock = 80,
                            Type = "Accessories"
                        },
                        new
                        {
                            Id = 10,
                            Brand = "Adidas",
                            Description = "Stylish sneakers for everyday wear",
                            Name = "Sneakers",
                            PictureUrl = "http://picsum.photos/200?id=7",
                            Price = 4000L,
                            PublicId = "sneakers_1",
                            QuantityInStock = 150,
                            Type = "Footwear"
                        },
                        new
                        {
                            Id = 11,
                            Brand = "Rolex",
                            Description = "Elegant wristwatch with leather strap",
                            Name = "Watch",
                            PictureUrl = "http://picsum.photos/200?id=8",
                            Price = 25000L,
                            PublicId = "watch_1",
                            QuantityInStock = 50,
                            Type = "Accessories"
                        },
                        new
                        {
                            Id = 12,
                            Brand = "Logitech",
                            Description = "Ergonomic wireless mouse for desktop use",
                            Name = "Wireless Mouse",
                            PictureUrl = "http://picsum.photos/200?id=9",
                            Price = 5000L,
                            PublicId = "mouse_1",
                            QuantityInStock = 100,
                            Type = "Electronics"
                        },
                        new
                        {
                            Id = 13,
                            Brand = "Lululemon",
                            Description = "Non-slip yoga mat for home workouts",
                            Name = "Yoga Mat",
                            PictureUrl = "http://picsum.photos/200?id=10",
                            Price = 3000L,
                            PublicId = "yogamat_1",
                            QuantityInStock = 120,
                            Type = "Fitness"
                        });
                });

            modelBuilder.Entity("API.Entities.BasketItem", b =>
                {
                    b.HasOne("API.Entities.Basket", "Basket")
                        .WithMany("Items")
                        .HasForeignKey("BasketId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("API.Entities.Basket", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
