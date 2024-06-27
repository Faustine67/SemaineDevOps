using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SemaineDevOps.Models;

namespace SemaineDevOps.Controllers
{
    public class EntreprisesController : Controller
    {
        private readonly SemaineDevOpsContext _context;

        public EntreprisesController(SemaineDevOpsContext context)
        {
            _context = context;
        }

        // GET: Entreprises
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entreprises.ToListAsync());
        }

        // GET: Entreprises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entreprise = await _context.Entreprises
                .Include(e=>e.Regroupers)
                    .ThenInclude(r => r.Question)
                        .ThenInclude(q => q.Categorie)
                            .ThenInclude(c => c.Axe)
                .Include(e => e.Regroupers)
                    .ThenInclude(r => r.Reponse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entreprise == null)
            {
                return NotFound();
            }

            return View(entreprise);
        }

        // GET: Entreprises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Entreprises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom,Domaine,Adresse,Cp,Ville")] Entreprise entreprise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(entreprise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(entreprise);
        }

        // GET: Entreprises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entreprise = await _context.Entreprises.FindAsync(id);
            if (entreprise == null)
            {
                return NotFound();
            }
            return View(entreprise);
        }

        // POST: Entreprises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom,Domaine,Adresse,Cp,Ville")] Entreprise entreprise)
        {
            if (id != entreprise.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(entreprise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EntrepriseExists(entreprise.Id))
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
            return View(entreprise);
        }

        // GET: Entreprises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var entreprise = await _context.Entreprises
                .FirstOrDefaultAsync(m => m.Id == id);
            if (entreprise == null)
            {
                return NotFound();
            }

            return View(entreprise);
        }

        // POST: Entreprises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entreprise = await _context.Entreprises.FindAsync(id);
            if (entreprise != null)
            {
                _context.Entreprises.Remove(entreprise);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EntrepriseExists(int id)
        {
            return _context.Entreprises.Any(e => e.Id == id);
        }
    }
}
