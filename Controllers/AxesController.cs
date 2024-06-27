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
    public class AxesController : Controller
    {
        private readonly SemaineDevOpsContext _context;

        public AxesController(SemaineDevOpsContext context)
        {
            _context = context;
        }

        // GET: Axes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Axes.ToListAsync());
        }

        // GET: Axes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var axe = await _context.Axes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (axe == null)
            {
                return NotFound();
            }

            return View(axe);
        }

        // GET: Axes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Axes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom")] Axe axe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(axe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(axe);
        }

        // GET: Axes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var axe = await _context.Axes.FindAsync(id);
            if (axe == null)
            {
                return NotFound();
            }
            return View(axe);
        }

        // POST: Axes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom")] Axe axe)
        {
            if (id != axe.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(axe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AxeExists(axe.Id))
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
            return View(axe);
        }

        // GET: Axes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var axe = await _context.Axes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (axe == null)
            {
                return NotFound();
            }

            return View(axe);
        }

        // POST: Axes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var axe = await _context.Axes.FindAsync(id);
            if (axe != null)
            {
                _context.Axes.Remove(axe);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AxeExists(int id)
        {
            return _context.Axes.Any(e => e.Id == id);
        }
    }
}
