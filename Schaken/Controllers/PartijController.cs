using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Schaken.DAL;
using Schaken.Models;

namespace Schaken.Controllers
{
    public class PartijController : Controller
    {
        private readonly SchakenContext _context;

        public PartijController(SchakenContext context)
        {
            _context = context;
        }

        // GET: Partij
        public async Task<IActionResult> Index()
        {
            var schakenContext = _context.Partij.Include(p => p.Speler);
            return View(await schakenContext.ToListAsync());
        }

        // GET: Partij/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partij = await _context.Partij
                .Include(p => p.Speler)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partij == null)
            {
                return NotFound();
            }

            return View(partij);
        }

        // GET: Partij/Create
        public IActionResult Create()
        {
            ViewData["SpelerId"] = new SelectList(_context.Speler, "Id", "Naam");
            return View();
        }

        // POST: Partij/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Dag,Uitslag,SpelerId")] Partij partij)
        {
            if (ModelState.IsValid)
            {
                _context.Add(partij);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpelerId"] = new SelectList(_context.Speler, "Id", "Naam", partij.SpelerId);
            return View(partij);
        }

        // GET: Partij/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partij = await _context.Partij.FindAsync(id);
            if (partij == null)
            {
                return NotFound();
            }
            ViewData["SpelerId"] = new SelectList(_context.Speler, "Id", "Naam", partij.SpelerId);
            return View(partij);
        }

        // POST: Partij/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dag,Uitslag,SpelerId")] Partij partij)
        {
            if (id != partij.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(partij);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PartijExists(partij.Id))
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
            ViewData["SpelerId"] = new SelectList(_context.Speler, "Id", "Naam", partij.SpelerId);
            return View(partij);
        }

        // GET: Partij/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var partij = await _context.Partij
                .Include(p => p.Speler)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (partij == null)
            {
                return NotFound();
            }

            return View(partij);
        }

        // POST: Partij/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var partij = await _context.Partij.FindAsync(id);
            _context.Partij.Remove(partij);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartijExists(int id)
        {
            return _context.Partij.Any(e => e.Id == id);
        }

        public async Task<IActionResult> CreateSpecial(int? Id, Dagen dag)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var speler = await _context.Speler.FindAsync(Id);
            if (speler == null)
            {
                return NotFound();
            }
            return View(new Partij { Speler = speler, SpelerId = speler.Id, Dag = dag });
        }
    }
}
