using Microsoft.AspNetCore.Mvc;
using WebApplication_MVC_GRUPO8.Context;
using WebApplication_MVC_GRUPO8.ViewModels;
namespace WebApplication_MVC_GRUPO8.Controllers
{
    public class AuthController : Controller
    {
        private readonly SistemaMantenimientoDBContext _context;

        public AuthController(SistemaMantenimientoDBContext context)
        {
            _context = context;
        }

        // GET: Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Buscar usuario
            var user = _context.Usuarios
          .FirstOrDefault(u => u.email == model.Email && u.password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Credenciales incorrectas");
                return View(model);
            }

            // Guardar datos en sesión
            HttpContext.Session.SetInt32("UserId", user.id);
            HttpContext.Session.SetString("UserNombre", $"{user.nombre} {user.apellido}");
            HttpContext.Session.SetString("UserRol", user.rol.ToString());

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

