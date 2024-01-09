using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.User;
using VirtualPetCare.Repository.Context;
using VirtualPetCareAPI.Controllers;
using VirtualPetCareAPI.Entities;
using Xunit;

namespace VirtualPetCare.Tests.Controllers
{
    public class UsersControllerTests
    {
        private UsersController _usersController;
        private Mock<PetCareDbContext> _mockDbContext;
        private Mock<IValidator<UserCreateDto>> _mockValidator;
        private Mock<IMapper> _mockMapper;



        public UsersControllerTests()
        {
            _mockDbContext = new Mock<PetCareDbContext>();
            _mockValidator = new Mock<IValidator<UserCreateDto>>();
            _mockMapper = new Mock<IMapper>();

            _usersController = new UsersController(_mockDbContext.Object, _mockMapper.Object);

        }

        [Fact]
        public async Task PostUser_ValidUser_ReturnsCreatedAtAction()
        {
            // Arrange
            var userDto = new UserCreateDto { /* initialize with valid data */ };
            var user = new User { /* initialize with valid data */ };

            _mockMapper.Setup(m => m.Map<UserCreateDto, User>(userDto)).Returns(user);

            // Act
            var result = await _usersController.PostUser(userDto) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("GetUser", result.ActionName);
            Assert.NotNull(result.RouteValues);
            Assert.True(result.RouteValues.ContainsKey("id"));
            Assert.Equal(user.Id, result.RouteValues["id"]);
        }

        [Fact]
        public async Task GetUser_ValidUserId_ReturnsUser()
        {
            // Arrange
            var userId = 1;
            var user = new User { Id = userId /* initialize with valid data */ };
            _mockDbContext.Setup(d => d.Users.FindAsync(userId)).ReturnsAsync(user);

            // Act
            var result = await _usersController.GetUser(userId) as ActionResult<User>;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<User>(result.Value);
            Assert.Equal(userId, result.Value.Id);
        }

        [Fact]
        public async Task GetUser_InvalidUserId_ReturnsNotFound()
        {
            // Arrange
            var userId = 1;
            _mockDbContext.Setup(d => d.Users.FindAsync(userId)).ReturnsAsync((User)null);

            // Act
            var result = await _usersController.GetUser(userId) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}
