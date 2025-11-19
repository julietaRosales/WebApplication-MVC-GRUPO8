using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication_MVC_GRUPO8.Context;
using WebApplication_MVC_GRUPO8.Models;
using WebApplication_MVC_GRUPO8.ViewModels;

namespace WebApplication_MVC_GRUPO8.Controllers
{
    public class ComentarioController : Controller
    {
        private readonly SistemaMantenimientoDBContext _context;

        public ComentarioController(SistemaMantenimientoDBContext context)
        {
            _context = context;
        }

        // GET: Comentario
        public async Task<IActionResult> Index()
        {
            return View(await _context.Comentarios.ToListAsync());
        }

        // GET: Comentario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios
                .FirstOrDefaultAsync(m => m.id == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // GET: Comentario/Create
        public IActionResult Create(int idIncidencia)
        {
            var vm = new ComentarioViewModel
            {
                idIncidencia = idIncidencia  // viene desde el detalle de incidencia
            };

            return View(vm);
        }

        // POST: Comentario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ComentarioViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var comentario = new Comentario
            {
                // El ID lo genera EF
                texto = model.texto,
                idUsuario = 1,                   // reemplazar cuando tenga el login
                fechaComentario = DateTime.Now,  // automatico
                idIncidencia = model.idIncidencia == 0
                ? 1 // quitar cuando tenga la incidencia real
                : model.idIncidencia
            };

            _context.Comentarios.Add(comentario);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Comentario agregado correctamente";

            return RedirectToAction(nameof(Index));
        }

        // GET: Comentario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario == null)
            {
                return NotFound();
            }
            return View(comentario);
        }

        // POST: Comentario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,texto,idUsuario,fechaComentario,idIncidencia")] Comentario comentario)
        {
            if (id != comentario.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comentario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComentarioExists(comentario.id))
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
            return View(comentario);
        }

        // GET: Comentario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comentario = await _context.Comentarios
                .FirstOrDefaultAsync(m => m.id == id);
            if (comentario == null)
            {
                return NotFound();
            }

            return View(comentario);
        }

        // POST: Comentario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comentario = await _context.Comentarios.FindAsync(id);
            if (comentario != null)
            {
                _context.Comentarios.Remove(comentario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComentarioExists(int id)
        {
            return _context.Comentarios.Any(e => e.id == id);
        }
    }
}
