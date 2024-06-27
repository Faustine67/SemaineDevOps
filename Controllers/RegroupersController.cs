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
    public class RegroupersController : Controller
    {
        private readonly SemaineDevOpsContext _context;

        public RegroupersController(SemaineDevOpsContext context)
        {
            _context = context;
        }

        // GET: Regroupers
        public async Task<IActionResult> Index()
        {
            var semaineDevOpsContext = _context.Regroupers.Include(r => r.Entreprise).Include(r => r.Question).Include(r => r.Reponse);
            return View(await semaineDevOpsContext.ToListAsync());
        }

        // GET: Regroupers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regrouper = await _context.Regroupers
                .Include(r => r.Entreprise)
                .Include(r => r.Question)
                .Include(r => r.Reponse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regrouper == null)
            {
                return NotFound();
            }

            return View(regrouper);
        }

        // GET: Regroupers/Create
        public IActionResult Create()
        {
            ViewData["EntrepriseId"] = new SelectList(_context.Entreprises, "Id", "Id");
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id");
            ViewData["ReponseId"] = new SelectList(_context.Reponses, "Id", "Id");
            return View();
        }

        // POST: Regroupers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EntrepriseId,QuestionId,ReponseId")] Regrouper regrouper)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regrouper);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EntrepriseId"] = new SelectList(_context.Entreprises, "Id", "Id", regrouper.EntrepriseId);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", regrouper.QuestionId);
            ViewData["ReponseId"] = new SelectList(_context.Reponses, "Id", "Id", regrouper.ReponseId);
            return View(regrouper);
        }

        // GET: Regroupers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regrouper = await _context.Regroupers.FindAsync(id);
            if (regrouper == null)
            {
                return NotFound();
            }
            ViewData["EntrepriseId"] = new SelectList(_context.Entreprises, "Id", "Id", regrouper.EntrepriseId);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", regrouper.QuestionId);
            ViewData["ReponseId"] = new SelectList(_context.Reponses, "Id", "Id", regrouper.ReponseId);
            return View(regrouper);
        }

        // POST: Regroupers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EntrepriseId,QuestionId,ReponseId")] Regrouper regrouper)
        {
            if (id != regrouper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regrouper);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegrouperExists(regrouper.Id))
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
            ViewData["EntrepriseId"] = new SelectList(_context.Entreprises, "Id", "Id", regrouper.EntrepriseId);
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", regrouper.QuestionId);
            ViewData["ReponseId"] = new SelectList(_context.Reponses, "Id", "Id", regrouper.ReponseId);
            return View(regrouper);
        }

        // GET: Regroupers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regrouper = await _context.Regroupers
                .Include(r => r.Entreprise)
                .Include(r => r.Question)
                .Include(r => r.Reponse)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (regrouper == null)
            {
                return NotFound();
            }

            return View(regrouper);
        }

        // POST: Regroupers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regrouper = await _context.Regroupers.FindAsync(id);
            if (regrouper != null)
            {
                _context.Regroupers.Remove(regrouper);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegrouperExists(int id)
        {
            return _context.Regroupers.Any(e => e.Id == id);
        }
    }
}
