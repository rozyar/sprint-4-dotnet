using EcommerceAPI.Models;
using EcommerceAPI.Repositories;
using EcommerceAPI.Services;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EcommerceAPI.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductRepository> _mockRepo;
        private readonly IProductService _productService;

        public ProductServiceTests()
        {
            _mockRepo = new Mock<IProductRepository>();
            _productService = new ProductService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllProductsAsync_ShouldReturnAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Price = 10.99M },
                new Product { Id = 2, Name = "Product 2", Price = 19.99M }
            };

            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(products);

            // Act
            var result = await _productService.GetAllProductsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal("Product 1", result.First().Name);
        }

        [Fact]
        public async Task GetProductByIdAsync_ShouldReturnProduct()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Product 1", Price = 10.99M };
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(product);

            // Act
            var result = await _productService.GetProductByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Product 1", result.Name);
        }

        [Fact]
        public async Task GetProductByIdAsync_WhenProductDoesNotExist_ShouldReturnNull()
        {
            // Arrange
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((Product)null);

            // Act
            var result = await _productService.GetProductByIdAsync(1);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public async Task CreateProductAsync_ShouldCallAddAsync()
        {
            // Arrange
            var product = new Product { Id = 3, Name = "Product 3", Price = 29.99M };

            // Act
            await _productService.CreateProductAsync(product);

            // Assert
            _mockRepo.Verify(repo => repo.AddAsync(product), Times.Once);
        }

        [Fact]
        public async Task UpdateProductAsync_ShouldCallUpdateAsync()
        {
            // Arrange
            var product = new Product { Id = 1, Name = "Updated Product", Price = 15.99M };

            // Act
            await _productService.UpdateProductAsync(product);

            // Assert
            _mockRepo.Verify(repo => repo.UpdateAsync(product), Times.Once);
        }

        [Fact]
        public async Task DeleteProductAsync_ShouldCallDeleteAsync()
        {
            // Arrange
            var productId = 1;

            // Act
            await _productService.DeleteProductAsync(productId);

            // Assert
            _mockRepo.Verify(repo => repo.DeleteAsync(productId), Times.Once);
        }
    }
}
