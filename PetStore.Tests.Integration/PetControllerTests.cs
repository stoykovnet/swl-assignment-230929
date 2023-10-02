using System.Collections.Generic;
using System.Net.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using PetStore.API.Controllers;
using PetStore.API.Swagger.Controllers.Generated;
using PetStore.DataAccessLayer;
using PetStore.DataAccessLayer.Repositories;
using PetStore.DataAccessLayer.Repositories.Interfaces;
using PetStore.Mappers;
using PetStore.Services;
using PetStore.Services.Interfaces;
using Xunit;

namespace PetStore.Tests.Integration
{
    public class PetControllerTests
    {
        private readonly PetController petController;
        private readonly ServiceProvider serviceProvider;

        public PetControllerTests()
        {
            serviceProvider = new ServiceCollection()
                .AddAutoMapper(typeof(BaseProfile))
                .AddScoped<PetStoreContext>()
                .AddScoped<IPetRepository, PetRepository>()
                .AddScoped<IPetService, PetService>()
                .AddScoped<PetController>()
                .BuildServiceProvider();

            petController = serviceProvider.GetRequiredService<PetController>();
        }

        [Fact]
        public async void AddPet_ShouldSaveNewPetToDatabase()
        {
            // Arrange
            var petBody = new Pet
            {
                Id = 1,
                Name = "Test",
                Category = new Category() { Name = "Test" },
                PhotoUrls = new List<string>() { "url" },
                Status = "available",
                Tags = new List<Tag>() { new Tag() { Name = "Test" } }
            };

            // Act
            var response = await petController.AddPet(petBody);

            // Assert
            var result = Assert.IsType<OkResult>(response);
            Assert.Equal(200, result.StatusCode);
        }
    }
}
