using gestion_futbolistica_backend.Data;
using gestion_futbolistica_backend.Entities;

namespace gestion_futbolistica_backend.Services
{
    public class PlayersService
    {
        private readonly FootballContext _context;

        public PlayersService(FootballContext context)
        {
            _context = context;
        }

        public async Task AssignPlayerToTeamAsync(int playerId, int teamId)
        {
            var player = await _context.Players.FindAsync(playerId);
            if (player == null)
            {
                throw new ArgumentException("Player not found");
            }

            var team = await _context.Teams.FindAsync(teamId);
            if (team == null)
            {
                throw new ArgumentException("Team not found");
            }

            player.IdEquipo = teamId;
            await _context.SaveChangesAsync();
        }
    }
}
