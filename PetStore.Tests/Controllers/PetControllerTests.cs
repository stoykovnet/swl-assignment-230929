using AutoMapper;
using Moq;
using PetStore.API.Controllers;
using PetStore.Services.Interfaces;
using System.Collections.Generic;
using Xunit;
using PetStore.DataAccessLayer.Models;
using PetStore.API.Swagger.Controllers.Generated;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace PetStore.Tests.Controllers
{
    public class PetControllerTests
    {
        private readonly PetController petController;
        private readonly Mock<IPetService> petServiceMock = new Mock<IPetService>();
        private readonly Mock<IMapper> autoMapperMock = new Mock<IMapper>();

        public PetControllerTests()
        {
            petController = new PetController(petServiceMock.Object, autoMapperMock.Object);
        }

        [Fact]
        public async void FindPetsByTags_ShouldReturn()
        {
            // Arrange
            var tags = new List<string>() { "Super", "Cool", "Brave" };
            var petId = 0;
            var petName = "Terry";
            
            var tagId = 0;
            var tagName = "Cool";

            var petTags = new List<TagModel>() { new TagModel { Id = tagId, Name = tagName } };

            var petModels = new List<PetModel>()
            {
                new PetModel
                {
                    Id = petId,
                    Name = petName,
                    Tags = petTags
                }
            };

            petServiceMock.Setup(x => x.FindPetsByTags(tags))
                .Returns(petModels);

            autoMapperMock.Setup(x => x.Map<ICollection<Pet>>(petModels))
                .Returns(new List<Pet>()
                {
                    new Pet
                    {
                        Id = petId,
                        Name = petName,
                        Tags = new List<Tag>()
                        { 
                            new Tag() { Id = tagId, Name = tagName }
                        }
                    }
                });

            // Act
            var response = await petController.FindPetsByTags(tags);

            // Assert
            Assert.IsType<OkObjectResult>(response.Result);
            var okResult = (OkObjectResult)response.Result;
            
            Assert.NotNull(okResult.Value);

            var pets = (IList<Pet>)okResult.Value;
            Assert.All(pets.First().Tags, petTag =>
            {
                Assert.Contains(petTag.Name, tags);
            });
        }
    }
}
