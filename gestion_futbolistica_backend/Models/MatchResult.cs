using System.ComponentModel.DataAnnotations;

namespace gestion_futbolistica_backend.Models
{
    public class MatchResult
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha del partido es obligatoria.")]
        public DateTime Fecha { get; set; }

        // Claves foráneas para equipos
        [Required(ErrorMessage = "El ID del equipo local es obligatorio.")]
        public int IdEquipoLocal { get; set; }

        [Required(ErrorMessage = "El ID del equipo visitante es obligatorio.")]
        public int IdEquipoVisitante { get; set; }

        [Range(0, 99, ErrorMessage = "Los goles locales deben estar entre 0 y 99.")]
        public int GolesLocal { get; set; }

        [Range(0, 99, ErrorMessage = "Los goles visitantes deben estar entre 0 y 99.")]
        public int GolesVisitante { get; set; }

        // Nombres de equipos
        public string? EquipoLocalNombre { get; set; }
        public string? EquipoVisitanteNombre { get; set; }
    }
}
