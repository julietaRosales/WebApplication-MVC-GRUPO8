using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;
using Microsoft.EntityFrameworkCore;
using WebApplication_MVC_GRUPO8.Context;
using WebApplication_MVC_GRUPO8.Models;
using WebApplication_MVC_GRUPO8.ViewModels;

namespace WebApplication_MVC_GRUPO8.Controllers
{
    public class IncidenciaController : Controller
    {
        //accede a la base de dato
        private readonly SistemaMantenimientoDBContext _context;
        //permite acceder a wwroot para guardar las imagenes
        private readonly IWebHostEnvironment _webHostEnvironment;

        // Constructor con inyección de dependencias
        public IncidenciaController(
            SistemaMantenimientoDBContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // INDEX - Listar todas las incidencias
        public async Task<IActionResult> Index()
        {
            var incidencias = await _context.Incidencias
                .Include(i => i.Usuario)
                .Include(i => i.Categoria)
                .Include(i => i.Tecnico)
                .ToListAsync();

            return View(incidencias);
        }
        private void CargarCategorias()
        {
            ViewBag.Categorias = new SelectList(
                _context.Categorias.Where(c => c.categoriaActivo),
                "id",
                "nombre"
            );
        }

        // CREATE - GET (Mostrar formulario)
        public IActionResult Create()
        {
            // Cargar las categorías activas para el dropdown
            CargarCategorias();

            return View();
        }

        // CREATE - POST (Guardar incidencia)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ReporteIncidenciaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                CargarCategorias();
                return View(model);
            }

            if (model.ImagenIncidencia == null || model.ImagenIncidencia.Length == 0)
            {
                ModelState.AddModelError("ImagenIncidencia", "Debe cargar una imagen.");
                CargarCategorias();
                return View(model);
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            string rutaTemp = null;

            try
            {
                //Guardamos la imagen primero con un nombre temporal
                rutaTemp = await GuardarImagenTemporal(model.ImagenIncidencia);

                // Crear incidencia
                var incidencia = new Incidencia
                {
                    titulo = model.Titulo,
                    descripcion = model.Descripcion,
                    fechaReporte = DateTime.Now,
                    idCategoria = model.IdCategoria,
                    idUsuario = 1,
                    estadoIncidencia = EstadoIncidencia.reportado,
                    imagenIncidencia = rutaTemp // guardamos la temporal
                };

                _context.Incidencias.Add(incidencia);
                await _context.SaveChangesAsync();

                //Confirmaacion transacción
                await transaction.CommitAsync();

                TempData["Success"] = $"Incidencia - {incidencia.titulo} - reportada exitosamente";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                // Si creamos una imagen temporal, eliminarla
                if (rutaTemp != null)
                {
                    var rutaFisica = Path.Combine(_webHostEnvironment.WebRootPath, rutaTemp.TrimStart('/'));
                    if (System.IO.File.Exists(rutaFisica))
                    {
                        System.IO.File.Delete(rutaFisica);
                    }
                }

                ModelState.AddModelError("", "Error al guardar la incidencia. Intente nuevamente.");
                //descomentar solo para ver errores
                //ModelState.AddModelError("", ex.Message);
                //ModelState.AddModelError("", "INNER: " + (ex.InnerException?.Message ?? "(sin inner exception)"));
                CargarCategorias();
                return View(model);
            }
        }

        // DETAILS - Ver detalles de una incidencia
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidencia = await _context.Incidencias
                .Include(i => i.Usuario)
                .Include(i => i.Categoria)
                .Include(i => i.Encargado)
                .Include(i => i.Tecnico)
                .Include(i => i.Comentarios)
                .FirstOrDefaultAsync(m => m.id == id);

            if (incidencia == null)
            {
                return NotFound();
            }

            var comentarios = await _context.Comentarios
            .Where(c => c.idIncidencia == id)
            .Join(
                _context.Usuarios,
                c => c.idUsuario,
                u => u.id,
                (c, u) => new ComentarioListaVM
                {
                    Id = c.id,
                    Texto = c.texto,
                    FechaComentario = c.fechaComentario,
                    NombreUsuario = u.nombre,
                    ApellidoUsuario = u.apellido
                }
            )
            .ToListAsync();

            ViewBag.Comentarios = comentarios;
            // TODO: Obtener el usuario logueado real
            int idUsuarioActual = 0; // CAMBIAR cuando tenga autenticacion
            RolUsuario rolUsuarioActual = RolUsuario.administrador; // CAMBIAR

            // Obtener el usuario actual de la BD para saber su rol
            var usuarioActual = await _context.Usuarios.FindAsync(idUsuarioActual);
            if (usuarioActual != null)
            {
                rolUsuarioActual = usuarioActual.rol;
            }

            // Pasar datos a la vista
            ViewBag.RolUsuarioActual = rolUsuarioActual;
            ViewBag.IdUsuarioActual = idUsuarioActual;
            ViewBag.EsTecnicoAsignado = incidencia.idTecnico == idUsuarioActual;


            // Mapear a ViewModel
            var viewModel = new DetalleIncidenciaViewModel
            {
                Id = incidencia.id,
                Titulo = incidencia.titulo,
                Descripcion = incidencia.descripcion,
                ImagenIncidencia = incidencia.imagenIncidencia,
                FechaReporte = incidencia.fechaReporte,
                EstadoIncidencia = incidencia.estadoIncidencia,
                Prioridad = incidencia.prioridad,
                Complejidad = incidencia.complejidad,
                NombreUsuarioReporta = $"{incidencia.Usuario?.nombre} {incidencia.Usuario?.apellido}",
                NombreEncargado = incidencia.Encargado != null ?
                    $"{incidencia.Encargado.nombre} {incidencia.Encargado.apellido}" : "Sin asignar",
                NombreTecnico = incidencia.Tecnico != null ?
                    $"{incidencia.Tecnico.nombre} {incidencia.Tecnico.apellido}" : "Sin asignar",
                NombreCategoria = incidencia.Categoria?.nombre ?? "Sin categoría",
                FechaAsignacion = incidencia.fechaAsignacion,
                Sla = incidencia.sla,
                JustificacionDescarte = incidencia.justificacionDescarte,
                FechaInicioReparacion = incidencia.fechaInicioReparacion,
                FechaFinReparacion = incidencia.fechaFinReparacion,
                CostoTotal = incidencia.costoTotal,
                DescripcionGasto = incidencia.descripcionGasto,
                ImagenFinalIncidencia = incidencia.imagenFinalIncidencia,
                Comentarios = incidencia.Comentarios.ToList()
            };

            return View(viewModel);
        }

        // GET: Incidencia/Asignar/x
        public async Task<IActionResult> Asignar(int id)

        {
            CargarCategorias();
            var incidencia = await _context.Incidencias
                .Include(i => i.Usuario)
                .Include(i => i.Categoria)
                .FirstOrDefaultAsync(i => i.id == id);

            if (incidencia == null)
                return NotFound();

            var vm = new AsignacionIncidenciaViewModel
            {
                IdIncidencia = incidencia.id,
                Titulo = incidencia.titulo,
                Descripcion = incidencia.descripcion,
                ImagenIncidencia = incidencia.imagenIncidencia,
                NombreUsuario = $"{incidencia.Usuario?.nombre} {incidencia.Usuario?.apellido}",
                FechaReporte = incidencia.fechaReporte,
                NombreCategoria = incidencia.Categoria?.nombre ?? "Sin categoría",
                IdTecnico = incidencia.idTecnico ?? 1,
                Prioridad = incidencia.prioridad,
                Complejidad = incidencia.complejidad
            };

             ViewBag.Tecnicos = new SelectList(
                 _context.Usuarios
                .Where(u => u.rol == RolUsuario.tecnico && u.userActivo)
                .Select(u => new
                {
                    u.id,
                    nombre = u.nombre + " " + u.apellido
                })
                .ToList(),
                   "id",
                   "nombre",
                   incidencia.idTecnico
                    );

            ViewBag.Prioridades = Enum.GetValues(typeof(Prioridad))
                          .Cast<Prioridad>()
                          .Select(p => new SelectListItem
                          {
                              Value = ((int)p).ToString(),
                              Text = p.ToString(),
                              Selected = incidencia.prioridad == p
                          })
                          .ToList();

            ViewBag.Complejidades = Enum.GetValues(typeof(Complejidad))
                                .Cast<Complejidad>()
                                .Select(c => new SelectListItem
                                {
                                    Value = ((int)c).ToString(),
                                    Text = c.ToString(),
                                    Selected = incidencia.complejidad == c
                                })
                                .ToList();


            return View(vm);
        }

        private void CargarListasAsignacion(int? idTecnicoSeleccionado = null,Prioridad ? prioridadSeleccionada = null, Complejidad? complejidadSeleccionada = null)
        {
            ViewBag.Tecnicos = new SelectList(
                _context.Usuarios
                    .Where(u => u.rol == RolUsuario.tecnico && u.userActivo)
                    .Select(u => new
                    {
                        u.id,
                        nombre = u.nombre + " " + u.apellido
                    })
                    .ToList(),
                "id",
                "nombre",
                idTecnicoSeleccionado
            );

            ViewBag.Prioridades = Enum.GetValues(typeof(Prioridad))
                .Cast<Prioridad>()
                .Select(p => new SelectListItem
                {
                    Value = ((int)p).ToString(),
                    Text = p.ToString(),
                    Selected = prioridadSeleccionada == p
                })
                .ToList();

            ViewBag.Complejidades = Enum.GetValues(typeof(Complejidad))
                .Cast<Complejidad>()
                .Select(c => new SelectListItem
                {
                    Value = ((int)c).ToString(),
                    Text = c.ToString(),
                    Selected = complejidadSeleccionada == c
                })
                .ToList();
        }

        // POST Asignar incidencia
        [HttpPost]
        public async Task<IActionResult> Asignar(AsignacionIncidenciaViewModel model)
        {

            if (!ModelState.IsValid)
            {
                // Volver a cargar SELECTS
                CargarListasAsignacion(model.IdTecnico,model.Prioridad, model.Complejidad);

                // Volver a cargar datos de la incidencia para reconstruir la CARD
                var incidencia = await _context.Incidencias
                    .Include(i => i.Usuario)
                    .Include(i => i.Categoria)
                    .FirstOrDefaultAsync(i => i.id == model.IdIncidencia);

                if (incidencia != null)
                {
                    model.Titulo = incidencia.titulo;
                    model.Descripcion = incidencia.descripcion;
                    model.ImagenIncidencia = incidencia.imagenIncidencia;
                    model.NombreCategoria = incidencia.Categoria?.nombre ?? "Sin categoría";
                    model.NombreUsuario = $"{incidencia.Usuario?.nombre} {incidencia.Usuario?.apellido}";
                    model.FechaReporte = incidencia.fechaReporte;
                }

                return View(model);
            }

            var inc = await _context.Incidencias
                .Include(i => i.Comentarios)
                .FirstOrDefaultAsync(i => i.id == model.IdIncidencia);

            if (inc == null)
                return NotFound();

            inc.idTecnico = model.IdTecnico;
            inc.prioridad = model.Prioridad;
            inc.complejidad = model.Complejidad;
            inc.idEncargado = 1; //TOO:MODIFICAR CUANDO TENGA EL USUARIO LOGEADO
            inc.fechaAsignacion = DateTime.Now;
            inc.sla = CalcularSLA(model.Prioridad, model.Complejidad);
            inc.estadoIncidencia = EstadoIncidencia.asignado;

            if (!string.IsNullOrWhiteSpace(model.ComentarioNuevo))
            {
                inc.Comentarios.Add(new Comentario
                {
                    texto = model.ComentarioNuevo,
                    fechaComentario = DateTime.Now,
                    idUsuario = 1,//TOO:MODIFICAR CUANDO TENGA EL USUARIO LOGEADO
                    idIncidencia = inc.id
                });
            }

            await _context.SaveChangesAsync();
            TempData["Success"] = $"Incidencia - {inc.titulo} - asignada exitosamente";
            return RedirectToAction("Index");
        }

        private decimal CalcularSLA(Prioridad? prioridad, Complejidad? complejidad)
        {
            if (!prioridad.HasValue || !complejidad.HasValue)
                return 24m; // 24 horas por defecto

            var matrizSLA = new Dictionary<(Prioridad, Complejidad), decimal>
    {
        { (Prioridad.baja, Complejidad.facil), 168m},      // 1 semana
        { (Prioridad.baja, Complejidad.intermedio), 336m },     // 2 semanas
        { (Prioridad.baja, Complejidad.dificil), 564m },     // 4 semanas
        
        { (Prioridad.media, Complejidad.facil), 48m },     // 2 día
        { (Prioridad.media, Complejidad.intermedio), 92m },    // 4 dias
        { (Prioridad.media, Complejidad.dificil), 504m  },     // 3 semanas

        { (Prioridad.alta, Complejidad.facil), 24m },       // 1 dia
        { (Prioridad.alta, Complejidad.intermedio), 120m },     // 5 dias
        { (Prioridad.alta, Complejidad.dificil),  504m },      // 2 semana
      
    };

            // Buscar el SLA correspondiente
            var key = (prioridad.Value, complejidad.Value);
            return matrizSLA.ContainsKey(key) ? matrizSLA[key] : 24m;
        }
        private async Task<string> GuardarImagenTemporal(IFormFile archivo)
        {
            var extensionesPermitidas = new[] { ".jpg", ".jpeg", ".png", ".gif" };
            var extension = Path.GetExtension(archivo.FileName).ToLowerInvariant();

            if (!extensionesPermitidas.Contains(extension))
                throw new Exception("Solo se permiten archivos .jpg, .jpeg, .png o .gif");

            if (archivo.Length > 5 * 1024 * 1024)
                throw new Exception("El archivo no puede ser mayor a 5MB");

            string nombreArchivo = $"temp-{Guid.NewGuid()}{extension}";

            string carpetaDestino = Path.Combine(
                _webHostEnvironment.WebRootPath,
                "images",
                "incidencias"
            );

            if (!Directory.Exists(carpetaDestino))
                Directory.CreateDirectory(carpetaDestino);

            string rutaCompleta = Path.Combine(carpetaDestino, nombreArchivo);

            using (var stream = new FileStream(rutaCompleta, FileMode.Create))
            {
                await archivo.CopyToAsync(stream);
            }

            return $"/images/incidencias/{nombreArchivo}";
        }

        // MÉTODO AUXILIAR - Verificar si existe
        private bool IncidenciaExists(int id)
        {
            return _context.Incidencias.Any(e => e.id == id);
        }
    }
}