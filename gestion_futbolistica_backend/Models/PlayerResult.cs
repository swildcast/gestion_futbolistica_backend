using System.ComponentModel.DataAnnotations;

namespace gestion_futbolistica_backend.Models
{
    public class PlayerResult
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del jugador es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "La posición es obligatoria")]
        [StringLength(50, ErrorMessage = "La posición no puede exceder 50 caracteres")]
        public string Posicion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(16, 50, ErrorMessage = "La edad debe estar entre 16 y 50 años")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El ID del equipo es obligatorio")]
        public int IdEquipo { get; set; }

        public string? EquipoNombre { get; set; }
    }
}
