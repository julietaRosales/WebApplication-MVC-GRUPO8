using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_MVC_GRUPO8.Models
{
    public class Incidencia
    {
        public int id { get; set; }
        public string titulo { get; set; }
        public string descripcion { get; set; }
        public string imagenIncidencia { get; set; }
        public DateTime fechaReporte { get; set; }
        public int idUsuario { get; set; }
        public int idCategoria { get; set; }

        [EnumDataType(typeof(EstadoIncidencia))]
        public EstadoIncidencia estadoIncidencia { get; set; }

        public int? idEncargado { get; set; }
        public int? idTecnico { get; set; }
        public DateTime? fechaAsignacion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? sla { get; set; }

        [EnumDataType(typeof(Prioridad))]
        public Prioridad? prioridad { get; set; }

        [EnumDataType(typeof(Complejidad))]
        public Complejidad? complejidad { get; set; }

        public string? justificacionDescarte { get; set; }
        public DateTime? fechaInicioReparacion { get; set; }
        public DateTime? fechaFinReparacion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? costoTotal { get; set; }

        public string? descripcionGasto { get; set; }
        public string?imagenFinalIncidencia { get; set; }

        [ForeignKey("idUsuario")]
        public virtual User Usuario { get; set; }

        [ForeignKey("idCategoria")]
        public virtual Categoria Categoria { get; set; }

        [ForeignKey("idEncargado")]
        public virtual User Encargado { get; set; }

        [ForeignKey("idTecnico")]
        public virtual User Tecnico { get; set; }
        public virtual ICollection<Comentario> Comentarios { get; set; }
    }
}
