using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestion_futbolistica_backend.Entities
{
    public class Match
    {
        [Key]
        public int Id { get; set; }

        public DateTime Fecha { get; set; }

        public int IdEquipoLocal { get; set; }

        [ForeignKey("IdEquipoLocal")]
        public Team? EquipoLocal { get; set; }

        public int IdEquipoVisitante { get; set; }

        [ForeignKey("IdEquipoVisitante")]
        public Team? EquipoVisitante { get; set; }

        public int GolesLocal { get; set; }

        public int GolesVisitante { get; set; }
    }
}
