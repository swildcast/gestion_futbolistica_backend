using gestion_futbolistica_backend.Data;
using gestion_futbolistica_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace gestion_futbolistica_backend.Services
{
    public class PlayersService
    {
        private readonly ApplicationDbContext _context;

        public PlayersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Player> CreatePlayerAsync(Player player)
        {
            // Check if team exists
            var team = await _context.Teams.FindAsync(player.IdEquipo);
            if (team == null)
            {
                throw new ArgumentException("Invalid team ID");
            }
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task UpdatePlayerAsync(int id, Player player)
        {
            if (id != player.Id)
            {
                throw new ArgumentException("ID mismatch");
            }
            // Check if team exists
            var team = await _context.Teams.FindAsync(player.IdEquipo);
            if (team == null)
            {
                throw new ArgumentException("Invalid team ID");
            }
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
