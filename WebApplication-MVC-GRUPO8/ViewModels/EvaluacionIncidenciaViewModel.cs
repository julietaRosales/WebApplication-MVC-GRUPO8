using System.ComponentModel.DataAnnotations;
using WebApplication_MVC_GRUPO8.Models;

namespace WebApplication_MVC_GRUPO8.ViewModels
{
    public class EvaluacionIncidenciaViewModel
    {
        public int IdIncidencia { get; set; }

        // Datos de la incidencia (para mostrar en la vista)
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Imagen")]
        public string ImagenIncidencia { get; set; }

        [Display(Name = "Prioridad")]
        public Prioridad? Prioridad { get; set; }

        [Display(Name = "Complejidad")]
        public Complejidad? Complejidad { get; set; }

        [Display(Name = "SLA (horas estimadas)")]
        public decimal? Sla { get; set; }

        // Campos que el técnico debe completar
        [Required(ErrorMessage = "El comentario de evaluación es obligatorio")]
        [MaxLength(1000, ErrorMessage = "El comentario no puede exceder 1000 caracteres")]
        [Display(Name = "Comentario de Evaluación")]
        [DataType(DataType.MultilineText)]
        public string ComentarioEvaluacion { get; set; }

        [Required(ErrorMessage = "Debe indicar si va a reparar o descartar")]
        [Display(Name = "¿Va a reparar esta incidencia?")]
        public bool VaAReparar { get; set; }

        [Display(Name = "Justificación del Descarte")]
        [DataType(DataType.MultilineText)]
        public string JustificacionDescarte { get; set; }

        // Propiedad de ayuda para validación condicional
        public bool RequiereJustificacion => !VaAReparar;
    }
}