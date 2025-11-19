using System.ComponentModel.DataAnnotations;
using WebApplication_MVC_GRUPO8.Models;
namespace WebApplication_MVC_GRUPO8.ViewModels

{
    public class ReporteIncidenciaViewModel
    {
        [Required(ErrorMessage = "El título es obligatorio")]
        [MaxLength(200, ErrorMessage = "El título no puede exceder 200 caracteres")]
        [Display(Name = "Título de la Incidencia")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [MaxLength(1000, ErrorMessage = "La descripción no puede exceder 1000 caracteres")]
        [Display(Name = "Descripción del Problema")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "La foto es obligatoria")]
        [Display(Name = "Foto del Problema")]
        public IFormFile ImagenIncidencia { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una categoría")]
        [Display(Name = "Categoría")]
        public int IdCategoria { get; set; }

        // Estos campos se asignarán automáticamente en el Controller
        public DateTime FechaReporte { get; set; } = DateTime.Now;
        public int IdUsuario { get; set; }
        public EstadoIncidencia EstadoIncidencia { get; set; } = EstadoIncidencia.reportado;
    }
}
