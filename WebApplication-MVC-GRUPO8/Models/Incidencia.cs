using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_MVC_GRUPO8.Models
{
    public class Incidencia
    {
        public int id { get; set; }
        public String titulo { get; set; }
        public String descripcion { get; set; }
        public String imagenIncidencia { get; set; }
        public DateTime fechaReporte { get; set; }
        public int idUsuario { get; set; }
        public int idEncargado { get; set; }
        public int idTecnico { get; set; }
        public DateTime fechaAsignacion { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal sla { get; set; }
        public String justificacionDescarte { get; set; }
        public DateTime fechaInicioReparacion {get;set;}
        public DateTime fechaFinReparacion { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal costoTotal { get; set; }
        public String descripcionGasto { get; set; }
        public String imagenFinalIncidencia { get; set; }

        [EnumDataType(typeof(Prioridad))]
        public Prioridad prioridad { get; set; }
        [EnumDataType(typeof(EstadoIncidencia))]
        public EstadoIncidencia estadoIncidencia { get; set; }

        [EnumDataType(typeof(Complejidad))]
        public Complejidad complejidad { get; set; }

    }
}
