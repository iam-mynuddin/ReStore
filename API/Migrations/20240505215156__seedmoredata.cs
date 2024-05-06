using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class _seedmoredata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Description", "Name", "PictureUrl", "Price", "PublicId", "QuantityInStock", "Type" },
                values: new object[,]
                {
                    { 4, "Dell", "High-performance laptop with SSD storage", "Laptop", "http://picsum.photos/200?id=1", 120000L, "laptop_1", 50, "Electronics" },
                    { 5, "Samsung", "Latest smartphone with OLED display", "Smartphone", "http://picsum.photos/200?id=2", 80000L, "smartphone_1", 100, "Electronics" },
                    { 6, "Sony", "Wireless headphones with noise cancellation", "Headphones", "http://picsum.photos/200?id=3", 30000L, "headphones_1", 75, "Electronics" },
                    { 7, "Nike", "Comfortable cotton t-shirt", "T-shirt", "http://picsum.photos/200?id=4", 2000L, "tshirt_1", 200, "Clothing" },
                    { 8, "Breville", "Automatic coffee maker with grinder", "Coffee Maker", "http://picsum.photos/200?id=5", 50000L, "coffeemaker_1", 30, "Kitchen Appliances" },
                    { 9, "The North Face", "Durable backpack for outdoor activities", "Backpack", "http://picsum.photos/200?id=6", 6000L, "backpack_1", 80, "Accessories" },
                    { 10, "Adidas", "Stylish sneakers for everyday wear", "Sneakers", "http://picsum.photos/200?id=7", 4000L, "sneakers_1", 150, "Footwear" },
                    { 11, "Rolex", "Elegant wristwatch with leather strap", "Watch", "http://picsum.photos/200?id=8", 25000L, "watch_1", 50, "Accessories" },
                    { 12, "Logitech", "Ergonomic wireless mouse for desktop use", "Wireless Mouse", "http://picsum.photos/200?id=9", 5000L, "mouse_1", 100, "Electronics" },
                    { 13, "Lululemon", "Non-slip yoga mat for home workouts", "Yoga Mat", "http://picsum.photos/200?id=10", 3000L, "yogamat_1", 120, "Fitness" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
