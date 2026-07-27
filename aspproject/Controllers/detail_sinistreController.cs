using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspproject.Data;
using aspproject.Models;
using Microsoft.AspNetCore.Authorization;

namespace aspproject.Controllers
{
    
    [Authorize]
    public class detail_sinistreController : Controller
    {
        private readonly MyDbContext _context;

        public detail_sinistreController(MyDbContext context)
        {
            _context = context;
        }

        // GET: detail_sinistre
        public async Task<IActionResult> Index()
        {
            return View(await _context.detail_sinistre.Take(500).ToListAsync());
        }

        // GET: detail_sinistre/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail_sinistre = await _context.detail_sinistre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detail_sinistre == null)
            {
                return NotFound();
            }

            return View(detail_sinistre);
        }

        // GET: detail_sinistre/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: detail_sinistre/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Numero_police,Numero_sinistre,Date_Sinistre,Etat_Dossier,Montant_Reserve,Montant_Reglement,Montant_Encaisse,crma_id,assure_id")] detail_sinistre detail_sinistre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detail_sinistre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detail_sinistre);
        }

        // GET: detail_sinistre/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail_sinistre = await _context.detail_sinistre.FindAsync(id);
            if (detail_sinistre == null)
            {
                return NotFound();
            }
            return View(detail_sinistre);
        }

        // POST: detail_sinistre/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Numero_police,Numero_sinistre,Date_Sinistre,Etat_Dossier,Montant_Reserve,Montant_Reglement,Montant_Encaisse,crma_id,assure_id")] detail_sinistre detail_sinistre)
        {
            if (id != detail_sinistre.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detail_sinistre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!detail_sinistreExists(detail_sinistre.Id))
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
            return View(detail_sinistre);
        }

        // GET: detail_sinistre/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail_sinistre = await _context.detail_sinistre
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detail_sinistre == null)
            {
                return NotFound();
            }

            return View(detail_sinistre);
        }

        // POST: detail_sinistre/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detail_sinistre = await _context.detail_sinistre.FindAsync(id);
            if (detail_sinistre != null)
            {
                _context.detail_sinistre.Remove(detail_sinistre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool detail_sinistreExists(int id)
        {
            return _context.detail_sinistre.Any(e => e.Id == id);
        }
    }
}
