using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ejercicio2.Models;

namespace Ejercicio2.Controllers
{
    public class SeleccionesController : Controller
    {
        private readonly MundialDBContext _context;

        public SeleccionesController(MundialDBContext context)
        {
            _context = context;
        }

        // GET: Selecciones
        public async Task<IActionResult> Index()
        {
            var mundialDBContext = _context.Seleccion.Include(s => s.IdDirectorTNavigation);
            return View(await mundialDBContext.ToListAsync());
        }

        // GET: Selecciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seleccion = await _context.Seleccion
                .Include(s => s.IdDirectorTNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (seleccion == null)
            {
                return NotFound();
            }

            return View(seleccion);
        }

        // GET: Selecciones/Create
        public IActionResult Create()
        {
            ViewData["IdDirectorT"] = new SelectList(_context.DirectorT, "Id", "Id");
            return View();
        }

        // POST: Selecciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Grupo,Confederacion,IdDirectorT")] Seleccion seleccion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seleccion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDirectorT"] = new SelectList(_context.DirectorT, "Id", "Id", seleccion.IdDirectorT);
            return View(seleccion);
        }

        // GET: Selecciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seleccion = await _context.Seleccion.SingleOrDefaultAsync(m => m.Id == id);
            if (seleccion == null)
            {
                return NotFound();
            }
            ViewData["IdDirectorT"] = new SelectList(_context.DirectorT, "Id", "Id", seleccion.IdDirectorT);
            return View(seleccion);
        }

        // POST: Selecciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Grupo,Confederacion,IdDirectorT")] Seleccion seleccion)
        {
            if (id != seleccion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seleccion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeleccionExists(seleccion.Id))
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
            ViewData["IdDirectorT"] = new SelectList(_context.DirectorT, "Id", "Id", seleccion.IdDirectorT);
            return View(seleccion);
        }

        // GET: Selecciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seleccion = await _context.Seleccion
                .Include(s => s.IdDirectorTNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (seleccion == null)
            {
                return NotFound();
            }

            return View(seleccion);
        }

        // POST: Selecciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seleccion = await _context.Seleccion.SingleOrDefaultAsync(m => m.Id == id);
            _context.Seleccion.Remove(seleccion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeleccionExists(int id)
        {
            return _context.Seleccion.Any(e => e.Id == id);
        }
    }
}
