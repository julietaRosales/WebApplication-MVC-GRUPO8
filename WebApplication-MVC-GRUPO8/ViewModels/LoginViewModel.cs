using System.ComponentModel.DataAnnotations;

namespace WebApplication_MVC_GRUPO8.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "El emial es obligatorio")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El contraseña es obligatoria")]
        [Display(Name = "Password")]
        public string Password { get; set; }
    
}
}
