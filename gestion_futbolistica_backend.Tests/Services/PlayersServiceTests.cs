using Xunit;
using Moq;
using gestion_futbolistica_backend.Data;
using gestion_futbolistica_backend.Models;
using gestion_futbolistica_backend.Services;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace gestion_futbolistica_backend.Tests.Services
{
    public class PlayersServiceTests
    {
        private readonly Mock<ApplicationDbContext> _mockContext;
        private readonly Mock<DbSet<Team>> _mockTeams;
        private readonly Mock<DbSet<Player>> _mockPlayers;
        private readonly PlayersService _service;

        public PlayersServiceTests()
        {
            _mockContext = new Mock<ApplicationDbContext>();
            _mockTeams = new Mock<DbSet<Team>>();
            _mockPlayers = new Mock<DbSet<Player>>();
            _mockContext.Setup(c => c.Teams).Returns(_mockTeams.Object);
            _mockContext.Setup(c => c.Players).Returns(_mockPlayers.Object);
            _service = new PlayersService(_mockContext.Object);
        }

        [Fact]
        public async Task CreatePlayerAsync_ValidTeamId_ShouldSavePlayer()
        {
            // Arrange
            var team = new Team { Id = 1, Nombre = "Team A" };
            var player = new Player { Id = 1, Nombre = "Player 1", IdEquipo = 1 };
            _mockTeams.Setup(t => t.FindAsync(1)).ReturnsAsync(team);
            _mockPlayers.Setup(p => p.Add(It.IsAny<Player>())).Verifiable();
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            // Act
            var result = await _service.CreatePlayerAsync(player);

            // Assert
            Assert.Equal(player, result);
            _mockPlayers.Verify(p => p.Add(It.IsAny<Player>()), Times.Once);
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task CreatePlayerAsync_InvalidTeamId_ShouldThrowArgumentException()
        {
            // Arrange
            var player = new Player { Id = 1, Nombre = "Player 1", IdEquipo = 999 };
            _mockTeams.Setup(t => t.FindAsync(999)).ReturnsAsync((Team)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _service.CreatePlayerAsync(player));
            Assert.Equal("Invalid team ID", exception.Message);
        }

        [Fact]
        public async Task UpdatePlayerAsync_ValidTeamId_ShouldUpdatePlayer()
        {
            // Arrange
            var team = new Team { Id = 1, Nombre = "Team A" };
            var player = new Player { Id = 1, Nombre = "Player 1", IdEquipo = 1 };
            _mockTeams.Setup(t => t.FindAsync(1)).ReturnsAsync(team);
            _mockContext.Setup(c => c.SaveChangesAsync(default)).ReturnsAsync(1);

            // Act
            await _service.UpdatePlayerAsync(1, player);

            // Assert
            _mockContext.Verify(c => c.SaveChangesAsync(default), Times.Once);
        }

        [Fact]
        public async Task UpdatePlayerAsync_InvalidTeamId_ShouldThrowArgumentException()
        {
            // Arrange
            var player = new Player { Id = 1, Nombre = "Player 1", IdEquipo = 999 };
            _mockTeams.Setup(t => t.FindAsync(999)).ReturnsAsync((Team)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _service.UpdatePlayerAsync(1, player));
            Assert.Equal("Invalid team ID", exception.Message);
        }

        [Fact]
        public async Task UpdatePlayerAsync_IdMismatch_ShouldThrowArgumentException()
        {
            // Arrange
            var player = new Player { Id = 2, Nombre = "Player 1", IdEquipo = 1 };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _service.UpdatePlayerAsync(1, player));
            Assert.Equal("ID mismatch", exception.Message);
        }
    }
}
