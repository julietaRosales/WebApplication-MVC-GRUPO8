using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System;
using System.Collections.Generic;

namespace WebApplication_MVC_GRUPO8.Models
{
    public class User
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public String apellido { get; set; }
        public String email { get; set; }
        public String password { get; set; }
        public Boolean userActivo { get; set; }
        [EnumDataType(typeof(RolUsuario))]
        public RolUsuario rol { get; set; }



    }
}
