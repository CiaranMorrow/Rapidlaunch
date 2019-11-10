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
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="SafetyRatingsController"/> class
        /// </summary>
        /// <param name="context">The context.</param>

        public SafetyRatingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SafetyRatings
        /// <summary>
        /// Indexes this instance
        /// </summary>
        public async Task<IActionResult> Index()
        {
            return View(await _context.SafetyRatings.ToListAsync());
        }

        // GET: SafetyRatings/Details/5
        /// <summary>
        /// Details the specified identifier
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Throws a not found if id or details is empty 
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
        /// <summary>
        /// Creates this instance
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        // POST: SafetyRatings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the safetyRating record as specified by the user.
        /// </summary>
        /// <param name="safetyRating">The safety rating .</param>
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
        /// <summary>
        /// Edits the specified identifier
        /// </summary>
        /// <param name="id">The identifier.</param>
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
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="safetyRating">The safety rating.</param>
        /// dpesnt return anything
        [HttpPost]
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
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
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
        /// <summary>
        /// Confirms the deletion of a safety rating
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var safetyRating = await _context.SafetyRatings.FindAsync(id);
            _context.SafetyRatings.Remove(safetyRating);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Checks if the safety rating already exists
        /// </summary>
        /// <param name="id">The safety rating </param>
        private bool SafetyRatingExists(int id)
        {
            return _context.SafetyRatings.Any(e => e.safetyRatingID == id);
        }
    }
}
