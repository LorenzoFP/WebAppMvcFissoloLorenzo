using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAppMvcFissoloLorenzo.Data;
using WebAppMvcFissoloLorenzo.Models;

namespace WebAppMvcFissoloLorenzo.Controllers
{
    public class RichiestaRimbosoFissoloLorenzoController : Controller
    {
        private readonly WebAppMvcFissoloLorenzoContext _context;

        public RichiestaRimbosoFissoloLorenzoController(WebAppMvcFissoloLorenzoContext context)
        {
            _context = context;
        }

        // GET: RichiestaRimbosoFissoloLorenzo
        public async Task<IActionResult> Index(int Importo)
        {
            if (_context.RichiestaRimboso == null)
            {
                return Problem("Entity set 'MvcMovieContext.Movie'  is null.");
            }

            var richiesta = from m in _context.RichiestaRimboso
                         select m;

            if (Importo != 0)
            {
                richiesta = richiesta.Where(s => s.Importo < Importo);
            }

            return View(await richiesta.ToListAsync());
        }

        // GET: RichiestaRimbosoFissoloLorenzo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var richiestaRimboso = await _context.RichiestaRimboso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (richiestaRimboso == null)
            {
                return NotFound();
            }

            return View(richiestaRimboso);
        }

        // GET: RichiestaRimbosoFissoloLorenzo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RichiestaRimbosoFissoloLorenzo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cognome,DataRichiesta,Telefono,email,PartitaIva,Richiesta,Importo")] RichiestaRimboso richiestaRimboso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(richiestaRimboso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(richiestaRimboso);
        }

        // GET: RichiestaRimbosoFissoloLorenzo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var richiestaRimboso = await _context.RichiestaRimboso.FindAsync(id);
            if (richiestaRimboso == null)
            {
                return NotFound();
            }
            return View(richiestaRimboso);
        }

        // POST: RichiestaRimbosoFissoloLorenzo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cognome,DataRichiesta,Telefono,email,PartitaIva,Richiesta,Importo")] RichiestaRimboso richiestaRimboso)
        {
            if (id != richiestaRimboso.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(richiestaRimboso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RichiestaRimbosoExists(richiestaRimboso.Id))
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
            return View(richiestaRimboso);
        }

        // GET: RichiestaRimbosoFissoloLorenzo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var richiestaRimboso = await _context.RichiestaRimboso
                .FirstOrDefaultAsync(m => m.Id == id);
            if (richiestaRimboso == null)
            {
                return NotFound();
            }

            return View(richiestaRimboso);
        }

        // POST: RichiestaRimbosoFissoloLorenzo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var richiestaRimboso = await _context.RichiestaRimboso.FindAsync(id);
            if (richiestaRimboso != null)
            {
                _context.RichiestaRimboso.Remove(richiestaRimboso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RichiestaRimbosoExists(int id)
        {
            return _context.RichiestaRimboso.Any(e => e.Id == id);
        }
    }
}
