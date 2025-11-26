using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_MVC_GRUPO8.Context;
using WebApplication_MVC_GRUPO8.Models;
using WebApplication_MVC_GRUPO8.ViewModels;

namespace WebApplication_MVC_GRUPO8.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SistemaMantenimientoDBContext _context;

    public HomeController(
        ILogger<HomeController> logger,
        SistemaMantenimientoDBContext context)
    {
        _logger = logger;
        _context = context;
    }


    public async Task<IActionResult> Index()
    {
        var incidencias = await _context.Incidencias
            .Include(i => i.Categoria)
            .OrderByDescending(i => i.fechaReporte)
            .ToListAsync();

        var vm = new DashboardViewModel
        {
            Activas = incidencias.Count(i => i.estadoIncidencia == EstadoIncidencia.reportado),
            EnProceso = incidencias.Count(i =>
                          i.estadoIncidencia == EstadoIncidencia.asignado ||
                          i.estadoIncidencia == EstadoIncidencia.enReparacion),
            Finalizadas = incidencias.Count(i => i.estadoIncidencia == EstadoIncidencia.finalizado),
            Descartadas = incidencias.Count(i => i.estadoIncidencia == EstadoIncidencia.descartado),
            Recientes = incidencias.Take(2).ToList(),
        };

        return View(vm);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
