using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using gestion_futbolistica_backend.Controllers;
using gestion_futbolistica_backend.Data;
using gestion_futbolistica_backend.Models;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace gestion_futbolistica_backend.Tests
{
    public class TeamsControllerTests
    {
        private async Task<ApplicationDbContext> GetDatabaseContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;

            var context = new ApplicationDbContext(options);

            // Agregar datos de prueba
            if (!await context.Teams.AnyAsync())
            {
                context.Teams.Add(new Team
                {
                    Id = 1,
                    Nombre = "FC Barcelona",
                    Ciudad = "Barcelona",
                    Estadio = "Camp Nou",
                    AñoFundacion = 1899
                });
                await context.SaveChangesAsync();
            }

            return context;
        }

        [Fact]
        public async Task GetTeams_ReturnsListOfTeams()
        {
            // Arrange
            var context = await GetDatabaseContext();
            var controller = new TeamsController(context);

            // Act
            var result = await controller.GetTeams();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Team>>>(result);
            var teams = Assert.IsType<List<Team>>(actionResult.Value);
            Assert.Single(teams);
            Assert.Equal("FC Barcelona", teams[0].Nombre);
        }

        [Fact]
        public async Task GetTeam_WithValidId_ReturnsTeam()
        {
            // Arrange
            var context = await GetDatabaseContext();
            var controller = new TeamsController(context);

            // Act
            var result = await controller.GetTeam(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Team>>(result);
            var team = Assert.IsType<Team>(actionResult.Value);
            Assert.Equal(1, team.Id);
            Assert.Equal("FC Barcelona", team.Nombre);
        }

        [Fact]
        public async Task GetTeam_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            var context = await GetDatabaseContext();
            var controller = new TeamsController(context);

            // Act
            var result = await controller.GetTeam(999);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}