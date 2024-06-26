using API.Controllers;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace API.Tests.Controllers
{
    public class ProductsControllerTests
    {
        [Fact]
        public async Task GetProducts_ReturnsOkResult_WithProductsList()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1" },
                new Product { Id = 2, Name = "Product 2" }
            }.AsQueryable();

            var mockDbSet = new Mock<DbSet<Product>>();
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            mockDbSet.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(products.GetEnumerator());

            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(c => c.Products).Returns(mockDbSet.Object);

            var controller = new ProductsController(mockContext.Object);

            // Act
            var result = await controller.GetProducts(orderBy: null, searchTerm: null);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<List<Product>>(okResult.Value);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task GetProduct_ReturnsNotFound_WhenProductNotFound()
        {
            // Arrange
            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(c => c.Products.FindAsync(It.IsAny<int>())).ReturnsAsync((Product)null);

            var controller = new ProductsController(mockContext.Object);

            // Act
            var result = await controller.GetProduct(id: 3); // Assuming a product with ID 3 doesn't exist

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetProduct_ReturnsProduct_WhenProductFound()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product 1" };

            var mockContext = new Mock<StoreContext>();
            mockContext.Setup(c => c.Products.FindAsync(It.IsAny<int>())).ReturnsAsync(product);

            var controller = new ProductsController(mockContext.Object);

            // Act
            var result = await controller.GetProduct(id: 1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsType<Product>(okResult.Value);
            Assert.Equal(product.Id, model.Id);
            Assert.Equal(product.Name, model.Name);
        }
    }
}
