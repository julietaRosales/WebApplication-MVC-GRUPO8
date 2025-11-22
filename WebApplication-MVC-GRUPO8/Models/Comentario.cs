using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication_MVC_GRUPO8.Models
{
    public class Comentario
    {
        public int id { get; set; }
        public String texto { get; set; }
        public int idUsuario { get; set; }

        [Display(Name = "Fecha del comentario")]
        public DateTime fechaComentario { get; set; }
        public int idIncidencia { get; set; }

        [ForeignKey("idIncidencia")]
        public virtual Incidencia Incidencia { get; set; }
    }
}
