using Moq;
using PetStore.DataAccessLayer;
using PetStore.DataAccessLayer.Models;
using PetStore.DataAccessLayer.Repositories;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PetStore.Tests.Repositories
{
    public class PetRepositoryTests
    {
        private readonly PetRepository petRepository;
        private readonly Mock<PetStoreContext> DbContextMock = new Mock<PetStoreContext>();

        public PetRepositoryTests()
        {
            petRepository = new PetRepository(DbContextMock.Object);
        }

        [Fact]
        public void FindPetsByTags_ShouldReturn()
        {
            // Arrange
            var tags = new List<string>() { "Super", "Cool", "Brave" };

            // Act
            var pets = petRepository.GetPetsByTags(tags);

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
            var tags = new List<string>() { "Slow" };

            // Act
            var pets = petRepository.GetPetsByTags(tags);

            // Assert
            Assert.Empty(pets);
        }
    }
}
