using System.ComponentModel.DataAnnotations; // Importante para [Required], [Range]

namespace gestion_futbolistica_backend.Models
{
    public class Match
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La fecha del partido es obligatoria.")]
        public DateTime Fecha { get; set; }

        // Claves foráneas para equipos
        [Required(ErrorMessage = "El ID del equipo local es obligatorio.")]
        public int IdEquipoLocal { get; set; }

        [Required(ErrorMessage = "El ID del equipo visitante es obligatorio.")]
        public int IdEquipoVisitante { get; set; }

        [Range(0, 99, ErrorMessage = "Los goles locales deben estar entre 0 y 99.")] // Ajusta el rango según necesites
        public int GolesLocal { get; set; }

        [Range(0, 99, ErrorMessage = "Los goles visitantes deben estar entre 0 y 99.")] // Ajusta el rango según necesites
        public int GolesVisitante { get; set; }

        // Relaciones de navegación (opcional para validaciones directas aquí, pero útiles para la lógica de negocio)
        // public Team EquipoLocal { get; set; } = null!;
        // public Team EquipoVisitante { get; set; } = null!;
    }
}