using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_MVC_GRUPO8.Context;
using WebApplication_MVC_GRUPO8.Models;

namespace WebApplication_MVC_GRUPO8.Controllers
{
    public class IncidenciaController : Controller
    {
        private readonly SistemaMantenimientoDBContext _context;

        public IncidenciaController(SistemaMantenimientoDBContext context)
        {
            _context = context;
        }

        // GET: Incidencia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Incidencias.ToListAsync());
        }

        // GET: Incidencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidencia = await _context.Incidencias
                .FirstOrDefaultAsync(m => m.id == id);
            if (incidencia == null)
            {
                return NotFound();
            }

            return View(incidencia);
        }

        // GET: Incidencia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Incidencia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,titulo,descripcion,imagenIncidencia,fechaReporte,idUsuario,idEncargado,idTecnico,fechaAsignacion,sla,justificacionDescarte,fechaInicioReparacion,fechaFinReparacion,costoTotal,descripcionGasto,imagenFinalIncidencia,prioridad,estadoIncidencia,complejidad")] Incidencia incidencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incidencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incidencia);
        }

        // GET: Incidencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidencia = await _context.Incidencias.FindAsync(id);
            if (incidencia == null)
            {
                return NotFound();
            }
            return View(incidencia);
        }

        // POST: Incidencia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,titulo,descripcion,imagenIncidencia,fechaReporte,idUsuario,idEncargado,idTecnico,fechaAsignacion,sla,justificacionDescarte,fechaInicioReparacion,fechaFinReparacion,costoTotal,descripcionGasto,imagenFinalIncidencia,prioridad,estadoIncidencia,complejidad")] Incidencia incidencia)
        {
            if (id != incidencia.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incidencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidenciaExists(incidencia.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(incidencia);
        }

        // GET: Incidencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidencia = await _context.Incidencias
                .FirstOrDefaultAsync(m => m.id == id);
            if (incidencia == null)
            {
                return NotFound();
            }

            return View(incidencia);
        }

        // POST: Incidencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incidencia = await _context.Incidencias.FindAsync(id);
            if (incidencia != null)
            {
                _context.Incidencias.Remove(incidencia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidenciaExists(int id)
        {
            return _context.Incidencias.Any(e => e.id == id);
        }
    }
}
