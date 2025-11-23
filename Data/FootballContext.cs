using gestion_futbolistica_backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace gestion_futbolistica_backend.Data
{
    public class FootballContext : DbContext
    {
        public FootballContext(DbContextOptions<FootballContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure relationships if needed, though DataAnnotations handle most
            modelBuilder.Entity<Match>()
                .HasOne(m => m.EquipoLocal)
                .WithMany()
                .HasForeignKey(m => m.IdEquipoLocal)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete

            modelBuilder.Entity<Match>()
                .HasOne(m => m.EquipoVisitante)
                .WithMany()
                .HasForeignKey(m => m.IdEquipoVisitante)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade delete
        }
    }
}
