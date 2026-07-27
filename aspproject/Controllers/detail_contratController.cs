using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using aspproject.Data;
using aspproject.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace aspproject.Controllers
{
    
    [Authorize]
    public class detail_contratController : Controller
    {
        
        private readonly MyDbContext _myContext;

        public detail_contratController(MyDbContext myContext)
        {
            _myContext = myContext;
        }


        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        // GET: detail_contrat
        public async Task<IActionResult> Index()
        {
            try
            {
                var contrats = await _myContext.detail_contrat
                    .Select(dc => new detail_contrat
                    {
                        Id = dc.Id,
                        crma_id = dc.crma_id,
                        exercice = dc.exercice,
                        assure_id = dc.assure_id,
                        numero_police = dc.numero_police,
                        date_police = dc.date_police,
                        numero_contrat = dc.numero_contrat,
                        date_effet = dc.date_effet,
                        date_expiration = dc.date_expiration,
                        prime_nette = dc.prime_nette,
                        complement = dc.complement,
                        taxes = dc.taxes,
                        timbres = dc.timbres,
                        montant_net_a_payer = dc.montant_net_a_payer
                        // Excluded Garanties to avoid circular reference
                    }).Take(500).ToListAsync();
                return View(contrats);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in Index: {ex.Message}\nStack Trace: {ex.StackTrace}");
                return View("Error");
            }
        }

        // GET: detail_contrat/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail_contrat = await _myContext.detail_contrat
                .Include(dc => dc.Garanties)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detail_contrat == null)
            {
                return NotFound();
            }

            return View(detail_contrat);
        }

        // GET: detail_contrat/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: detail_contrat/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,crma_id,exercice,assure_id,numero_police,date_police,numero_contrat,date_effet,date_expiration,prime_nette,complement,taxes,timbres,montant_net_a_payer")] detail_contrat detail_contrat)
        {
            if (ModelState.IsValid)
            {
                _myContext.Add(detail_contrat);
                await _myContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(detail_contrat);
        }

        // GET: detail_contrat/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail_contrat = await _myContext.detail_contrat.FindAsync(id);
            if (detail_contrat == null)
            {
                return NotFound();
            }
            return View(detail_contrat);
        }

        // POST: detail_contrat/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,crma_id,exercice,assure_id,numero_police,date_police,numero_contrat,date_effet,date_expiration,prime_nette,complement,taxes,timbres,montant_net_a_payer")] detail_contrat detail_contrat)
        {
            if (id != detail_contrat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _myContext.Update(detail_contrat);
                    await _myContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!detail_contratExists(detail_contrat.Id))
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
            return View(detail_contrat);
        }

        // GET: detail_contrat/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detail_contrat = await _myContext.detail_contrat
                .FirstOrDefaultAsync(m => m.Id == id);
            if (detail_contrat == null)
            {
                return NotFound();
            }

            return View(detail_contrat);
        }

        // POST: detail_contrat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var detail_contrat = await _myContext.detail_contrat.FindAsync(id);
            if (detail_contrat != null)
            {
                _myContext.detail_contrat.Remove(detail_contrat);
            }

            await _myContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool detail_contratExists(long id)
        {
            return _myContext.detail_contrat.Any(e => e.Id == id);
        }


        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGarantie([Bind("Id,Nom,CodeGarantie,Capital,Majoration,Reduction,PrimeNette,ContratId")] garantie garantie)
        {
            ModelState.Remove("detail_contrat");
            if (ModelState.IsValid)
            {
                _myContext.Add(garantie);
                await _myContext.SaveChangesAsync();

                // Redirect back to the contract's details page
                return RedirectToAction("Details", "detail_contrat", new { id = garantie.ContratId });
            }

            // If model state is invalid, re-fetch the detail_contrat and show the same page
            var detailContrat = await _myContext.detail_contrat
                .Include(dc => dc.Garanties)
                .FirstOrDefaultAsync(m => m.Id == garantie.ContratId);

            return View("Details", detailContrat); // Re-render the Details.cshtml view
        }







        [HttpGet]
        public IActionResult GetGarantiesByContratId(long contratId)
        {
            var garanties = _myContext.garantie
                .Where(g => g.ContratId == contratId)
                .Select(g => new {
                    g.Id,
                    g.Nom,
                    g.ContratId,
                    g.CodeGarantie,
                    g.Capital,
                    g.Majoration,
                    g.Reduction,
                    g.PrimeNette
                }).ToList();

            return Json(garanties);
        }
       


    }
}
