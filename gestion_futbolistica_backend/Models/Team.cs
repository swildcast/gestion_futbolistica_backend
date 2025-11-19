using System.ComponentModel.DataAnnotations;

namespace gestion_futbolistica_backend.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del equipo es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La ciudad es obligatoria")]
        [StringLength(100, ErrorMessage = "La ciudad no puede exceder 100 caracteres")]
        public string Ciudad { get; set; } = string.Empty;

        [Required(ErrorMessage = "El estadio es obligatorio")]
        [StringLength(100, ErrorMessage = "El estadio no puede exceder 100 caracteres")]
        public string Estadio { get; set; } = string.Empty;

        [Required(ErrorMessage = "El año de fundación es obligatorio")]
        [Range(1800, 2024, ErrorMessage = "El año de fundación debe estar entre 1800 y 2024")]
        public int AñoFundacion { get; set; }

        // TEMPORALMENTE COMENTAR RELACIONES (para evitar errores):
        // public List<Player> Players { get; set; } = new List<Player>();
        // public List<Match> MatchesLocal { get; set; } = new List<Match>();
        // public List<Match> MatchesVisitante { get; set; } = new List<Match>();
    }
}   