using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using gestion_futbolistica_backend.Controllers;
using gestion_futbolistica_backend.Data;
using gestion_futbolistica_backend.Models;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace gestion_futbolistica_backend.Tests
{
    public class TeamsControllerTests
    {
        [Fact]
        public async Task GetTeams_ReturnsListOfTeams()
        {
            // Arrange
            var teams = new List<Team>
            {
                new Team { Id = 1, Nombre = "FC Barcelona", Ciudad = "Barcelona", Estadio = "Camp Nou", AñoFundacion = 1899 },
                new Team { Id = 2, Nombre = "Real Madrid", Ciudad = "Madrid", Estadio = "Santiago Bernabéu", AñoFundacion = 1902 }
            };

            var mockTeams = new Mock<DbSet<Team>>();
            mockTeams.As<IQueryable<Team>>().Setup(m => m.Provider).Returns(teams.AsQueryable().Provider);
            mockTeams.As<IQueryable<Team>>().Setup(m => m.Expression).Returns(teams.AsQueryable().Expression);
            mockTeams.As<IQueryable<Team>>().Setup(m => m.ElementType).Returns(teams.AsQueryable().ElementType);
            mockTeams.As<IQueryable<Team>>().Setup(m => m.GetEnumerator()).Returns(teams.GetEnumerator());

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Teams).Returns(mockTeams.Object);

            var controller = new TeamsController(mockContext.Object);

            // Act
            var result = await controller.GetTeams();

            // Assert
            var actionResult = Assert.IsType<ActionResult<IEnumerable<Team>>>(result);
            var returnedTeams = Assert.IsType<List<Team>>(actionResult.Value);
            Assert.Equal(2, returnedTeams.Count);
            Assert.Equal("FC Barcelona", returnedTeams[0].Nombre);
            Assert.Equal("Real Madrid", returnedTeams[1].Nombre);
        }

        [Fact]
        public async Task PostTeam_CreatesTeamAndReturnsCreatedAtAction()
        {
            // Arrange
            var team = new Team { Id = 1, Nombre = "FC Barcelona", Ciudad = "Barcelona", Estadio = "Camp Nou", AñoFundacion = 1899 };

            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Teams.Add(team));
            mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            var controller = new TeamsController(mockContext.Object);

            // Act
            var result = await controller.PostTeam(team);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal("GetTeam", actionResult.ActionName);
            Assert.Equal(team.Id, actionResult.RouteValues["id"]);
            Assert.Equal(team, actionResult.Value);

            mockContext.Verify(c => c.Teams.Add(team), Times.Once);
            mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }
    }
}
