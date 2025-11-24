using System.ComponentModel.DataAnnotations;
using WebApplication_MVC_GRUPO8.Models;

namespace WebApplication_MVC_GRUPO8.ViewModels
{
    public class DescarteIncidencia
    {
        public int IdIncidencia { get; set; }

        [Display(Name = "Título")]
        public string? Titulo { get; set; }

        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }

        [Display(Name = "Imagen")]
        public string? ImagenIncidencia { get; set; }

        [Display(Name = "Categoría")]

        public string? NombreCategoria { get; set; }

        [Display(Name = "Fecha de Reporte")]
        public DateTime FechaReporte { get; set; }

        [Display(Name = "Estado")]
        public EstadoIncidencia EstadoIncidencia { get; set; }

        [Required(ErrorMessage = "El campo justificación es obligatorio.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "La justificación debe tener entre 10 y 500 caracteres.")]
        public string JustificacionDescarte { get; set; }

        [Display(Name = "Fecha de Descarte")]
        public DateTime FechaDescarte { get; set; }
    }
}
