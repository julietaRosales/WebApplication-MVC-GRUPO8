using System.ComponentModel.DataAnnotations;
using WebApplication_MVC_GRUPO8.Models;

namespace WebApplication_MVC_GRUPO8.ViewModels
{
    public class AsignacionIncidenciaViewModel
    {
        public int IdIncidencia { get; set; }

        // Datos de la incidencia (para mostrar en la vista)
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Imagen")]
        public string ImagenIncidencia { get; set; }

        [Display(Name = "Reportado por")]
        public string NombreUsuario { get; set; }

        [Display(Name = "Fecha de Reporte")]
        public DateTime FechaReporte { get; set; }

        // Campos que el encargado debe completar
        [Required(ErrorMessage = "Debe seleccionar un técnico")]
        [Display(Name = "Técnico Asignado")]
        public int IdTecnico { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una prioridad")]
        [Display(Name = "Prioridad")]
        public Prioridad Prioridad { get; set; }

        [Required(ErrorMessage = "Debe seleccionar la complejidad")]
        [Display(Name = "Complejidad")]
        public Complejidad Complejidad { get; set; }

        [MaxLength(500, ErrorMessage = "Las observaciones no pueden exceder 500 caracteres")]
        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public string Observaciones { get; set; }

        // Nota: Estos campos se asignarán automáticamente en el Controller
        public DateTime FechaAsignacion { get; set; } = DateTime.Now;
        public decimal Sla { get; set; }
        public int IdEncargado { get; set; }
    }
}
