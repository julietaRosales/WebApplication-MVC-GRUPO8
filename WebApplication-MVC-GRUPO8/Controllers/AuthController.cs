using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebApplication_MVC_GRUPO8.Context;
using WebApplication_MVC_GRUPO8.ViewModels;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;

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
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Buscar usuario
            var user = _context.Usuarios
                .FirstOrDefault(u => u.email == model.Email && u.password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Error de contraseña o usuario");
                return View(model);
            }

            // Crear claims y autenticar con cookies
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.nombre} {user.apellido}"),
                new Claim(ClaimTypes.Email, user.email ?? string.Empty),
                new Claim(ClaimTypes.Role, user.rol.ToString())
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            // Guardar datos en sesión (opcional)
            HttpContext.Session.SetInt32("UserId", user.id);
            HttpContext.Session.SetString("UserNombre", $"{user.nombre} {user.apellido}");
            HttpContext.Session.SetString("UserRol", user.rol.ToString());

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

