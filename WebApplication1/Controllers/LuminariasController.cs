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
    public class LuminariasController : Controller
    {
        private readonly Context _context;

        public LuminariasController(Context context)
        {
            _context = context;
        }

        // GET: Luminarias
        public async Task<IActionResult> Index()
        {
              return _context.Luminaria != null ? 
                          View(await _context.Luminaria.ToListAsync()) :
                          Problem("Entity set 'Context.Luminaria'  is null.");
        }

        // GET: Luminarias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Luminaria == null)
            {
                return NotFound();
            }

            var luminaria = await _context.Luminaria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (luminaria == null)
            {
                return NotFound();
            }

            return View(luminaria);
        }

        // GET: Luminarias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Luminarias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Modelo,Cidade,Pais,id_cliente,id_grupo,Latitude,Longitude,Estado")] Luminaria luminaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(luminaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(luminaria);
        }

        // GET: Luminarias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Luminaria == null)
            {
                return NotFound();
            }

            var luminaria = await _context.Luminaria.FindAsync(id);
            if (luminaria == null)
            {
                return NotFound();
            }
            return View(luminaria);
        }

        // POST: Luminarias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Modelo,Cidade,Pais,id_cliente,id_grupo,Latitude,Longitude,Estado")] Luminaria luminaria)
        {
            if (id != luminaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(luminaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LuminariaExists(luminaria.Id))
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
            return View(luminaria);
        }

        // GET: Luminarias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Luminaria == null)
            {
                return NotFound();
            }

            var luminaria = await _context.Luminaria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (luminaria == null)
            {
                return NotFound();
            }

            return View(luminaria);
        }

        // POST: Luminarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Luminaria == null)
            {
                return Problem("Entity set 'Context.Luminaria'  is null.");
            }
            var luminaria = await _context.Luminaria.FindAsync(id);
            if (luminaria != null)
            {
                _context.Luminaria.Remove(luminaria);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LuminariaExists(int id)
        {
          return (_context.Luminaria?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
