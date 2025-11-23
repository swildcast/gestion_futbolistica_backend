using Microsoft.EntityFrameworkCore;
using gestion_futbolistica_backend.Models;

namespace gestion_futbolistica_backend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("teams");
                entity.Property(t => t.Id).HasColumnName("id");
                entity.Property(t => t.Nombre).HasColumnName("nombre");
                entity.Property(t => t.Ciudad).HasColumnName("ciudad");
                entity.Property(t => t.Estadio).HasColumnName("estadio");
                entity.Property(t => t.AñoFundacion).HasColumnName("año_fundacion");
            });
        }
    }
}