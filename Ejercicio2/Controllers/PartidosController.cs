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
    public class PartidosController : Controller
    {
        private readonly MundialDBContext _context;

        public PartidosController(MundialDBContext context)
        {
            _context = context;
        }

        // GET: Partidos
        public async Task<IActionResult> Index()
        {
            var mundialDBContext = _context.Partido.Include(p => p.IdEstadioNavigation);
            return View(await mundialDBContext.ToListAsync());
        }

        // GET: Partidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partido = await _context.Partido
                .Include(p => p.IdEstadioNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (partido == null)
            {
                return NotFound();
            }

            return View(partido);
        }

        // GET: Partidos/Create
        public IActionResult Create()
        {
            ViewData["IdEstadio"] = new SelectList(_context.Estadio, "Id", "Id");
            return View();
        }

        // POST: Partidos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Local,Visita,Marcador,IdEstadio")] Partido partido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEstadio"] = new SelectList(_context.Estadio, "Id", "Id", partido.IdEstadio);
            return View(partido);
        }

        // GET: Partidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partido = await _context.Partido.SingleOrDefaultAsync(m => m.Id == id);
            if (partido == null)
            {
                return NotFound();
            }
            ViewData["IdEstadio"] = new SelectList(_context.Estadio, "Id", "Id", partido.IdEstadio);
            return View(partido);
        }

        // POST: Partidos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Local,Visita,Marcador,IdEstadio")] Partido partido)
        {
            if (id != partido.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartidoExists(partido.Id))
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
            ViewData["IdEstadio"] = new SelectList(_context.Estadio, "Id", "Id", partido.IdEstadio);
            return View(partido);
        }

        // GET: Partidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partido = await _context.Partido
                .Include(p => p.IdEstadioNavigation)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (partido == null)
            {
                return NotFound();
            }

            return View(partido);
        }

        // POST: Partidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partido = await _context.Partido.SingleOrDefaultAsync(m => m.Id == id);
            _context.Partido.Remove(partido);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartidoExists(int id)
        {
            return _context.Partido.Any(e => e.Id == id);
        }
    }
}
