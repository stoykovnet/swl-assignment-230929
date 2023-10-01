using Moq;
using PetStore.DataAccessLayer.Models;
using PetStore.DataAccessLayer.Repositories.Interfaces;
using PetStore.Services;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PetStore.Tests.Services
{
    public class PetServiceTests
    {
        private readonly PetService petService;
        private readonly Mock<IPetRepository> petRepoMock = new Mock<IPetRepository>();

        public PetServiceTests()
        {
            petService = new PetService(petRepoMock.Object);
        }

        [Fact]
        public void GetPetById_ShouldReturn()
        {
            // Arrange
            var petId = 0;
            var petModel = new PetModel { 
                Id = petId, 
                Name = "Terry"
            };
            
            petRepoMock.Setup(x => x.GetById(petId))
                .Returns(petModel);

            // Act
            var pet = petService.GetPetById(petId);

            // Assert
            Assert.Equal(petId, pet.Id);
        }

        [Fact]
        public void GetPetById_ShouldNotReturn()
        {
            // Arrange
            var petId = 1;
            petRepoMock.Setup(x => x.GetById(petId))
                .Returns<PetModel>(null);

            // Act
            var pet = petService.GetPetById(petId);

            // Assert
            Assert.Null(pet);
        }

        [Fact]
        public void FindPetsByTags_ShouldReturn()
        {
            // Arrange
            var tags = new List<string>() { "Super", "Cool", "Brave" };
            var petModel = new PetModel
            {
                Id = 0,
                Name = "Terry",
                Tags = new List<TagModel>() { new TagModel { Id = 0, Name = "Cool" } }
            };

            petRepoMock.Setup(x => x.GetPetsByTags(tags))
                .Returns(new List<PetModel> { petModel });

            // Act
            var pets = petService.FindPetsByTags(tags);

            // Assert
            Assert.All(pets.First().Tags, petTag =>
            {
                Assert.Contains(petTag.Name, tags);
            });
        }

        [Fact]
        public void FindPetsByTags_ShouldNotReturn()
        {
            // Arrange
            var tags = new List<string>() { "Super", "Cool", "Brave" };
            var petModel = new PetModel
            {
                Id = 0,
                Name = "Terry",
                Tags = new List<TagModel>() { new TagModel { Id = 0, Name = "Slow" } }
            };

            petRepoMock.Setup(x => x.GetPetsByTags(tags))
                .Returns(new List<PetModel> { petModel });

            // Act
            var pet = petService.FindPetsByTags(tags);

            // Assert
            Assert.All(pet.First().Tags, petTag =>
            {
                Assert.DoesNotContain(petTag.Name, tags);
            });
        }
    }
}
