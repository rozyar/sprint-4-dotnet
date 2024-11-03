using EcommerceAPI.Models;
using EcommerceAPI.Repositories;
using EcommerceAPI.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace EcommerceAPI.Tests.Services
{
    public class UserServiceTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly IUserService _userService;

        public UserServiceTests()
        {
            _mockRepo = new Mock<IUserRepository>();
            _userService = new UserService(_mockRepo.Object);
        }

        [Fact]
        public async Task GetUserByIdAsync_ShouldReturnUser()
        {
            // Arrange
            var user = new User { Id = 1, FirstName = "John", LastName = "Doe", Email = "john@example.com" };
            _mockRepo.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(user);

            // Act
            var result = await _userService.GetUserByIdAsync(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("John", result.FirstName);
        }

        [Fact]
        public async Task GetUserByEmailAsync_ShouldReturnUser()
        {
            // Arrange
            var user = new User { Id = 1, FirstName = "John", Email = "john@example.com" };
            _mockRepo.Setup(repo => repo.GetByEmailAsync("john@example.com")).ReturnsAsync(user);

            // Act
            var result = await _userService.GetUserByEmailAsync("john@example.com");

            // Assert
            Assert.NotNull(result);
            Assert.Equal("john@example.com", result.Email);
        }

        [Fact]
        public async Task CreateUserAsync_ShouldCallAddAsync()
        {
            // Arrange
            var user = new User { Id = 2, FirstName = "Jane", LastName = "Doe", Email = "jane@example.com" };

            // Act
            await _userService.CreateUserAsync(user);

            // Assert
            _mockRepo.Verify(repo => repo.AddAsync(user), Times.Once);
        }

        [Fact]
        public async Task UpdateUserAsync_ShouldCallUpdateAsync()
        {
            // Arrange
            var user = new User { Id = 1, FirstName = "John Updated", Email = "john@example.com" };

            // Act
            await _userService.UpdateUserAsync(user);

            // Assert
            _mockRepo.Verify(repo => repo.UpdateAsync(user), Times.Once);
        }

        [Fact]
        public async Task DeleteUserAsync_ShouldCallDeleteAsync()
        {
            // Arrange
            var userId = 1;

            // Act
            await _userService.DeleteUserAsync(userId);

            // Assert
            _mockRepo.Verify(repo => repo.DeleteAsync(userId), Times.Once);
        }
    }
}
