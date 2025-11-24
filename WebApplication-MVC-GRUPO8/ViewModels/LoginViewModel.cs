using System.ComponentModel.DataAnnotations;

namespace WebApplication_MVC_GRUPO8.ViewModels
{
    public class LoginViewModel
    {
        
    [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    
}
}
