using System.ComponentModel.DataAnnotations;
using WebApplication_MVC_GRUPO8.Models;

namespace WebApplication_MVC_GRUPO8.ViewModels
{
    public class DetalleIncidenciaViewModel
    {
        // Datos básicos de la incidencia
        public int Id { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Imagen Inicial")]
        public string ImagenIncidencia { get; set; }

        [Display(Name = "Fecha de Reporte")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime FechaReporte { get; set; }

        [Display(Name = "Estado")]
        public EstadoIncidencia EstadoIncidencia { get; set; }

        // Datos de las personas involucradas
        [Display(Name = "Reportado por")]
        public string NombreUsuarioReporta { get; set; }

        [Display(Name = "Encargado")]
        public string NombreEncargado { get; set; }

        [Display(Name = "Técnico Asignado")]
        public string NombreTecnico { get; set; }

        [Display(Name = "Categoría")]
        public string NombreCategoria { get; set; }

        // Datos de asignación
        [Display(Name = "Prioridad")]
        public Prioridad? Prioridad { get; set; }

        [Display(Name = "Complejidad")]
        public Complejidad? Complejidad { get; set; }

        [Display(Name = "Fecha de Asignación")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? FechaAsignacion { get; set; }

        [Display(Name = "SLA (horas)")]
        public decimal? Sla { get; set; }

        // Datos de evaluación
        [Display(Name = "Justificación del Descarte")]
        public string JustificacionDescarte { get; set; }

        // Datos de reparación
        [Display(Name = "Fecha de Inicio de Reparación")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? FechaInicioReparacion { get; set; }

        [Display(Name = "Fecha de Finalización")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm}")]
        public DateTime? FechaFinReparacion { get; set; }

        [Display(Name = "Costo Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? CostoTotal { get; set; }

        [Display(Name = "Descripción del Gasto")]
        public string DescripcionGasto { get; set; }

        [Display(Name = "Imagen Final")]
        public string ImagenFinalIncidencia { get; set; }

        // Lista de comentarios asociados
        public List<Comentario> Comentarios { get; set; } = new List<Comentario>();
    }
}
