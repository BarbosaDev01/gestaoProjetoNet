using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class anexoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public anexoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: anexo
        public async Task<IActionResult> Index()
        {
              return _context.anexo != null ? 
                          View(await _context.anexo.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.anexo'  is null.");
        }

        // GET: anexo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.anexo == null)
            {
                return NotFound();
            }

            var anexo = await _context.anexo
                .FirstOrDefaultAsync(m => m.IdAnexo == id);
            if (anexo == null)
            {
                return NotFound();
            }

            return View(anexo);
        }

        // GET: anexo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: anexo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAnexo,PlantaPdf,IdProjeto")] anexo anexo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anexo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anexo);
        }

        // GET: anexo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.anexo == null)
            {
                return NotFound();
            }

            var anexo = await _context.anexo.FindAsync(id);
            if (anexo == null)
            {
                return NotFound();
            }
            return View(anexo);
        }

        // POST: anexo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAnexo,PlantaPdf,IdProjeto")] anexo anexo)
        {
            if (id != anexo.IdAnexo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anexo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!anexoExists(anexo.IdAnexo))
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
            return View(anexo);
        }

        // GET: anexo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.anexo == null)
            {
                return NotFound();
            }

            var anexo = await _context.anexo
                .FirstOrDefaultAsync(m => m.IdAnexo == id);
            if (anexo == null)
            {
                return NotFound();
            }

            return View(anexo);
        }

        // POST: anexo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.anexo == null)
            {
                return Problem("Entity set 'ApplicationDbContext.anexo'  is null.");
            }
            var anexo = await _context.anexo.FindAsync(id);
            if (anexo != null)
            {
                _context.anexo.Remove(anexo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool anexoExists(int id)
        {
          return (_context.anexo?.Any(e => e.IdAnexo == id)).GetValueOrDefault();
        }
    }
}
