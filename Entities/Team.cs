using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_futbolistica_backend.Entities
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Ciudad { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Estadio { get; set; } = string.Empty;

        [Column("AñoFundación")]
        public int AnioFundacion { get; set; }
    }
}
