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
    public class OrderServiceTests
    {
        private readonly Mock<IOrderRepository> _mockRepo;
        private readonly IOrderService _orderService;

        public OrderServiceTests()
        {
            _mockRepo = new Mock<IOrderRepository>();
            _orderService = new OrderService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetAllOrdersAsync_ShouldReturnAllOrders()
        {
            // Arrange
            var orders = new List<Order>
            {
                new Order { Id = 1, Status = "Pending" },
                new Order { Id = 2, Status = "Shipped" }
            };

            _mockRepo.Setup(repo => repo.GetAllAsync()).ReturnsAsync(orders);

            // Act
            var result = await _orderService.GetAllOrdersAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetOrderByIdAsync_ShouldReturnOrder()
        {
            // Arrange
            var order = new Order { Id = 1, Status = "Pending" };
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(order);

            // Act
            var result = await _orderService.GetOrderByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Pending", result.Status);
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldCallAddAsync()
        {
            // Arrange
            var order = new Order { Id = 3, Status = "Pending" };

            // Act
            await _orderService.CreateOrderAsync(order);

            // Assert
            _mockRepo.Verify(repo => repo.AddAsync(order), Times.Once);
        }

        [Fact]
        public async Task UpdateOrderAsync_ShouldCallUpdateAsync()
        {
            // Arrange
            var order = new Order { Id = 1, Status = "Completed" };

            // Act
            await _orderService.UpdateOrderAsync(order);

            // Assert
            _mockRepo.Verify(repo => repo.UpdateAsync(order), Times.Once);
        }

        [Fact]
        public async Task DeleteOrderAsync_ShouldCallDeleteAsync()
        {
            // Arrange
            var orderId = 1;

            // Act
            await _orderService.DeleteOrderAsync(orderId);

            // Assert
            _mockRepo.Verify(repo => repo.DeleteAsync(orderId), Times.Once);
        }
    }
}
