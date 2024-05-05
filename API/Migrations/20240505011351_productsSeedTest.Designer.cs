﻿// <auto-generated />
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20240505011351_productsSeedTest")]
    partial class productsSeedTest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

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
                            PictureUrl = "https://example.com/laptop.jpg",
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
                            PictureUrl = "https://example.com/smartphone.jpg",
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
                            PictureUrl = "https://example.com/headphones.jpg",
                            Price = 200L,
                            PublicId = "Test",
                            QuantityInStock = 30,
                            Type = "Electronics"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
