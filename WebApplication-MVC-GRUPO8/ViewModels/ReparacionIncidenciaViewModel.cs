using System.ComponentModel.DataAnnotations;

namespace WebApplication_MVC_GRUPO8.ViewModels
{
    public class ReparacionIncidenciaViewModel
    {
        public int IdIncidencia { get; set; }

        // Datos de la incidencia (para mostrar en la vista)
        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        // Campos que el técnico debe completar
        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        [Display(Name = "Fecha de Inicio")]
        [DataType(DataType.DateTime)]
        public DateTime FechaInicioReparacion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "La fecha de finalización es obligatoria")]
        [Display(Name = "Fecha de Finalización")]
        [DataType(DataType.DateTime)]
        public DateTime FechaFinReparacion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "El costo total es obligatorio")]
        [Range(0, double.MaxValue, ErrorMessage = "El costo debe ser mayor o igual a 0")]
        [Display(Name = "Costo Total ($)")]
        [DataType(DataType.Currency)]
        public decimal CostoTotal { get; set; }

        [Required(ErrorMessage = "La descripción del gasto es obligatoria")]
        [MaxLength(500, ErrorMessage = "La descripción no puede exceder 500 caracteres")]
        [Display(Name = "Descripción del Gasto")]
        [DataType(DataType.MultilineText)]
        public string DescripcionGasto { get; set; }

        [MaxLength(500, ErrorMessage = "Los comentarios no pueden exceder 500 caracteres")]
        [Display(Name = "Comentarios de Progreso")]
        [DataType(DataType.MultilineText)]
        public string ComentariosProgreso { get; set; }

        [Display(Name = "Foto Final (Opcional)")]
        public IFormFile ImagenFinalIncidencia { get; set; }
    }
}
