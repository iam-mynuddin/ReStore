using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class productsSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Description", "Name", "PictureUrl", "Price", "PublicId", "QuantityInStock", "Type" },
                values: new object[,]
                {
                    { 1, "ExampleBrand", "High-performance laptop with the latest technology", "Laptop", "https://example.com/laptop.jpg", 1500L, "363e34d2-e8f1-493e-9873-2e6735ba6d60", 50, "Electronics" },
                    { 2, "ExampleBrand", "Feature-packed smartphone with advanced camera", "Smartphone", "https://example.com/smartphone.jpg", 800L, "4763821a-01da-4a34-b1c2-871026cfe476", 100, "Electronics" },
                    { 3, "ExampleBrand", "High-quality headphones with noise-cancellation", "Headphones", "https://example.com/headphones.jpg", 200L, "6244f15d-1236-45fa-ba8d-c2bc0c26dd5b", 30, "Electronics" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
