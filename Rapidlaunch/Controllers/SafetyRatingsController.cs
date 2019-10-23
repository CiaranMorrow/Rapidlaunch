using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rapidlaunch.Data;
using Rapidlaunch.Models;

namespace Rapidlaunch.Controllers
{
    public class SafetyRatingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SafetyRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SafetyRatings
        public async Task<IActionResult> Index()
        {
            return View(await _context.SafetyRatings.ToListAsync());
        }

        // GET: SafetyRatings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyRating = await _context.SafetyRatings
                .FirstOrDefaultAsync(m => m.safetyRatingID == id);
            if (safetyRating == null)
            {
                return NotFound();
            }

            return View(safetyRating);
        }

        // GET: SafetyRatings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SafetyRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("safetyRatingID,safetyRating")] SafetyRating safetyRating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(safetyRating);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(safetyRating);
        }

        // GET: SafetyRatings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyRating = await _context.SafetyRatings.FindAsync(id);
            if (safetyRating == null)
            {
                return NotFound();
            }
            return View(safetyRating);
        }

        // POST: SafetyRatings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("safetyRatingID,safetyRating")] SafetyRating safetyRating)
        {
            if (id != safetyRating.safetyRatingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(safetyRating);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SafetyRatingExists(safetyRating.safetyRatingID))
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
            return View(safetyRating);
        }

        // GET: SafetyRatings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var safetyRating = await _context.SafetyRatings
                .FirstOrDefaultAsync(m => m.safetyRatingID == id);
            if (safetyRating == null)
            {
                return NotFound();
            }

            return View(safetyRating);
        }

        // POST: SafetyRatings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var safetyRating = await _context.SafetyRatings.FindAsync(id);
            _context.SafetyRatings.Remove(safetyRating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SafetyRatingExists(int id)
        {
            return _context.SafetyRatings.Any(e => e.safetyRatingID == id);
        }
    }
}
