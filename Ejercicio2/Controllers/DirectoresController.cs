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
    public class DirectoresController : Controller
    {
        private readonly MundialDBContext _context;

        public DirectoresController(MundialDBContext context)
        {
            _context = context;
        }

        // GET: Directores
        public async Task<IActionResult> Index()
        {
            return View(await _context.DirectorT.ToListAsync());
        }

        // GET: Directores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directorT = await _context.DirectorT
                .SingleOrDefaultAsync(m => m.Id == id);
            if (directorT == null)
            {
                return NotFound();
            }

            return View(directorT);
        }

        // GET: Directores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Directores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Nacionalidad")] DirectorT directorT)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directorT);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(directorT);
        }

        // GET: Directores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directorT = await _context.DirectorT.SingleOrDefaultAsync(m => m.Id == id);
            if (directorT == null)
            {
                return NotFound();
            }
            return View(directorT);
        }

        // POST: Directores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Nacionalidad")] DirectorT directorT)
        {
            if (id != directorT.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directorT);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectorTExists(directorT.Id))
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
            return View(directorT);
        }

        // GET: Directores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directorT = await _context.DirectorT
                .SingleOrDefaultAsync(m => m.Id == id);
            if (directorT == null)
            {
                return NotFound();
            }

            return View(directorT);
        }

        // POST: Directores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directorT = await _context.DirectorT.SingleOrDefaultAsync(m => m.Id == id);
            _context.DirectorT.Remove(directorT);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectorTExists(int id)
        {
            return _context.DirectorT.Any(e => e.Id == id);
        }
    }
}
