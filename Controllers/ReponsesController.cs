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
    public class ReponsesController : Controller
    {
        private readonly SemaineDevOpsContext _context;

        public ReponsesController(SemaineDevOpsContext context)
        {
            _context = context;
        }

        // GET: Reponses
        public async Task<IActionResult> Index()
        {
            var semaineDevOpsContext = _context.Reponses.Include(r => r.Question);
            return View(await semaineDevOpsContext.ToListAsync());
        }

        // GET: Reponses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponse = await _context.Reponses
                .Include(r => r.Question)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reponse == null)
            {
                return NotFound();
            }

            return View(reponse);
        }

        // GET: Reponses/Create
        public IActionResult Create()
        {
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id");
            return View();
        }

        // POST: Reponses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Score,Commentaire,QuestionId")] Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reponse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", reponse.QuestionId);
            return View(reponse);
        }

        // GET: Reponses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponse = await _context.Reponses.FindAsync(id);
            if (reponse == null)
            {
                return NotFound();
            }
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", reponse.QuestionId);
            return View(reponse);
        }

        // POST: Reponses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Score,Commentaire,QuestionId")] Reponse reponse)
        {
            if (id != reponse.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reponse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReponseExists(reponse.Id))
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
            ViewData["QuestionId"] = new SelectList(_context.Questions, "Id", "Id", reponse.QuestionId);
            return View(reponse);
        }

        // GET: Reponses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reponse = await _context.Reponses
                .Include(r => r.Question)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reponse == null)
            {
                return NotFound();
            }

            return View(reponse);
        }

        // POST: Reponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reponse = await _context.Reponses.FindAsync(id);
            if (reponse != null)
            {
                _context.Reponses.Remove(reponse);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReponseExists(int id)
        {
            return _context.Reponses.Any(e => e.Id == id);
        }
    }
}
