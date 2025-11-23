using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_futbolistica_backend.Entities
{
    public class Player
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(50)]
        [Column("Posición")]
        public string Posicion { get; set; } = string.Empty;

        [Range(0, 150)]
        public int Edad { get; set; }

        public int IdEquipo { get; set; }

        [ForeignKey("IdEquipo")]
        public Team? Equipo { get; set; }
    }
}
