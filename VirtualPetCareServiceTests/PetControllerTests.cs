using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VirtualPetCare.Core.DTOs.Pet;
using VirtualPetCare.Repository.Context;
using VirtualPetCareAPI.Controllers;
using VirtualPetCareAPI.Entities;
using Xunit;

namespace VirtualPetCare.Tests.Controllers
{
    public class PetControllerTests
    {
        private PetController _petController;
        private Mock<PetCareDbContext> _mockDbContext;
        private Mock<IMapper> _mockMapper;

        public PetControllerTests()
        {
            _mockDbContext = new Mock<PetCareDbContext>();
            _mockMapper = new Mock<IMapper>();

            _petController = new PetController(_mockDbContext.Object, _mockMapper.Object);
        }

        [Fact]
        public async Task PostPet_ValidPet_ReturnsCreatedAtAction()
        {
            // Arrange
            var petDto = new PetCreateDto { /* initialize with valid data */ };
            var pet = new Pet { /* initialize with valid data */ };

            _mockMapper.Setup(m => m.Map<PetCreateDto, Pet>(petDto)).Returns(pet);

            // Act
            var result = await _petController.PostPet(petDto) as CreatedAtActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("GetPet", result.ActionName);
            Assert.NotNull(result.RouteValues);
            Assert.True(result.RouteValues.ContainsKey("petId"));
            Assert.Equal(pet.Id, result.RouteValues["petId"]);
        }

        [Fact]
        public async Task GetPets_ReturnsListOfPets()
        {
            // Arrange
            var pets = new List<Pet> { /* initialize with valid data */ };
            _mockDbContext.Setup(d => d.Pets.AsQueryable().ToListAsync()).ReturnsAsync(pets);

            // Act
            var result = await _petController.GetPets() as ActionResult<IEnumerable<Pet>>;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult?.Value);

            // Düzeltme: Gerçekleşen değeri beklenen türle elde et
            Assert.IsType<List<Pet>>(okResult.Value);

            var petList = (List<Pet>)okResult.Value;
            Assert.Equal(pets.Count, petList.Count);
        }

        [Fact]
        public async Task GetPet_ValidPetId_ReturnsPet()
        {
            // Arrange
            var petId = 1;
            var pet = new Pet { Id = petId /* initialize with valid data */ };
            _mockDbContext.Setup(d => d.Pets.FindAsync(petId)).ReturnsAsync(pet);

            // Act
            var result = await _petController.GetPet(petId) as ActionResult<Pet>;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);

            var okResult = result.Result as OkObjectResult;
            Assert.NotNull(okResult?.Value);
            Assert.IsType<Pet>(okResult.Value);

            var retrievedPet = okResult.Value as Pet;
            Assert.Equal(pet.Id, retrievedPet.Id);
        }

        [Fact]
        public async Task GetPet_InvalidPetId_ReturnsNotFound()
        {
            // Arrange
            var petId = 1;
            _mockDbContext.Setup(d => d.Pets.FindAsync(petId)).ReturnsAsync((Pet)null);

            // Act
            var result = await _petController.GetPet(petId) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}
