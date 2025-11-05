using System.ComponentModel.DataAnnotations;

namespace WebApplication_MVC_GRUPO8.Models
{
    public class Categoria
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public Boolean categoriaActivo { get; set; }
        
    }
}
