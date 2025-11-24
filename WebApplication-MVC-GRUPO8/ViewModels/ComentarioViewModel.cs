using System.ComponentModel.DataAnnotations;

namespace WebApplication_MVC_GRUPO8.ViewModels
{
    public class ComentarioViewModel
    {
        [Required(ErrorMessage = "El comentario es obligatorio.")]
        [StringLength(300, ErrorMessage = "El comentario no puede superar los 300 caracteres.")]
        [Display(Name = "Comentario")]
        public String texto { get; set; }
        public int idIncidencia { get; set; }

    }
}
