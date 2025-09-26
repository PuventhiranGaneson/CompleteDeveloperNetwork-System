using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CompleteDeveloperNetwork_System.Controllers;
using CompleteDeveloperNetwork_System.Data;
using CompleteDeveloperNetwork_System.Dto;
using CompleteDeveloperNetwork_System.Models;
using CompleteDeveloperNetwork_System.Tests;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace CompleteDeveloperNetwork_System.Tests
{
    public class DevelopersControllerTests
    {
        [Fact]
        public async Task GetDevelopers_ReturnsAll()
        {
            // Arrange
            using var context = TestHelper.GetInMemoryContext();
            context.developers.Add(new Developers { Id = 1, Username = "alice", Email = "alice@test.com" });
            context.developers.Add(new Developers { Id = 2, Username = "bob", Email = "bob@test.com" });
            await context.SaveChangesAsync();

            var controller = new DevelopersController(context);

            // Act
            var result = await controller.GetDeveloperById(99);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var devs = Assert.IsAssignableFrom<IEnumerable<DeveloperDto>>(ok.Value);
            Assert.Equal(2, devs.Count());
        }

        [Fact]
        public async Task GetDeveloperById_ReturnsDeveloper_WhenExists()
        {
            // Arrange
            using var context = TestHelper.GetInMemoryContext();
            context.developers.Add(new Developers { Id = 1, Username = "alice", Email = "alice@test.com" });
            await context.SaveChangesAsync();

            var controller = new DevelopersController(context);

            // Act
            var result = await controller.GetDeveloperById(1);

            // Assert
            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var dev = Assert.IsType<DeveloperDto>(ok.Value);
            Assert.Equal("alice", dev.Username);
        }

        [Fact]
        public async Task GetDeveloperById_ReturnsNotFound_WhenNotExists()
        {
            using var context = TestHelper.GetInMemoryContext();
            var controller = new DevelopersController(context);

            var result = await controller.GetDeveloperById(99);

            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task SearchDevelopers_ByUsername_Works()
        {
            using var context = TestHelper.GetInMemoryContext();
            context.developers.Add(new Developers { Id = 1, Username = "alice", Email = "alice@test.com" });
            context.developers.Add(new Developers { Id = 2, Username = "bob", Email = "bob@test.com" });
            await context.SaveChangesAsync();

            var controller = new DevelopersController(context);

            var result = await controller.SearchDevelopers("alice", null);

            var ok = Assert.IsType<OkObjectResult>(result.Result);
            var devs = Assert.IsAssignableFrom<IEnumerable<DeveloperDto>>(ok.Value);
            Assert.Single(devs);
            Assert.Equal("alice", devs.First().Username);
        }

        [Fact]
        public async Task SearchDevelopers_ReturnsNotFound_WhenNoMatch()
        {
            using var context = TestHelper.GetInMemoryContext();
            context.developers.Add(new Developers { Id = 1, Username = "alice", Email = "alice@test.com" });
            await context.SaveChangesAsync();

            var controller = new DevelopersController(context);

            var result = await controller.SearchDevelopers("bob", null);

            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}
