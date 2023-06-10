using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class GruposController : Controller
    {
        private readonly Context _context;

        public GruposController(Context context)
        {
            _context = context;
        }

        // GET: Grupos
        public async Task<IActionResult> Index()
        {
              return _context.Grupo != null ? 
                          View(await _context.Grupo.ToListAsync()) :
                          Problem("Entity set 'Context.Grupo'  is null.");
        }

        // GET: Grupos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Grupo == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // GET: Grupos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Grupos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Grupo grupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(grupo);
        }

        // GET: Grupos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Grupo == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupo.FindAsync(id);
            if (grupo == null)
            {
                return NotFound();
            }
            return View(grupo);
        }

        // POST: Grupos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Grupo grupo)
        {
            if (id != grupo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GrupoExists(grupo.Id))
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
            return View(grupo);
        }

        // GET: Grupos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Grupo == null)
            {
                return NotFound();
            }

            var grupo = await _context.Grupo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grupo == null)
            {
                return NotFound();
            }

            return View(grupo);
        }

        // POST: Grupos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Grupo == null)
            {
                return Problem("Entity set 'Context.Grupo'  is null.");
            }
            var grupo = await _context.Grupo.FindAsync(id);
            if (grupo != null)
            {
                _context.Grupo.Remove(grupo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GrupoExists(int id)
        {
          return (_context.Grupo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
