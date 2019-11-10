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
    public class StaffSafetyRecordsController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="StaffSafetyRecordsController"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public StaffSafetyRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StaffSafetyRecords
        /// <summary>
        /// Indexes this instance
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StaffSafetyRecords.Include(s => s.SafetyRating).Include(s => s.Staff);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StaffSafetyRecords/Details/5
        /// <summary>
        /// Details the specified identifier
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();  // Throws a not found if id or details is empty 
            }

            var staffSafetyRecord = await _context.StaffSafetyRecords
                .Include(s => s.SafetyRating)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.safetyRatingID == id);
            if (staffSafetyRecord == null)
            {
                return NotFound();
            }

            return View(staffSafetyRecord);
        }

        // GET: StaffSafetyRecords/Create
        /// <summary>
        /// Creates this instance
        /// </summary>
        public IActionResult Create()
        {
            ViewData["safetyRatingID"] = new SelectList(_context.SafetyRatings, "safetyRatingID", "safetyRatingID");
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID");
            return View();
        }

        // POST: StaffSafetyRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the StaffSafetyRecords record as specified by the user.
        /// </summary>
        /// <param name="staffSafetyRecord">The StaffSafetyRecords.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("staffID,safetyRatingID")] StaffSafetyRecord staffSafetyRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffSafetyRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["safetyRatingID"] = new SelectList(_context.SafetyRatings, "safetyRatingID", "safetyRatingID", staffSafetyRecord.safetyRatingID);
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID", staffSafetyRecord.staffID);
            return View(staffSafetyRecord);
        }

        // GET: StaffSafetyRecords/Edit/5
        /// <summary>
        /// Edits the specified identifier
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="id2">The identifier.</param>
        public async Task<IActionResult> Edit(int? id , int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }

            var staffSafetyRecord = await _context.StaffSafetyRecords.FindAsync(id, id2);
            if (staffSafetyRecord == null )
            {
                return NotFound();
            }
            ViewData["safetyRatingID"] = new SelectList(_context.SafetyRatings, "safetyRatingID", "safetyRatingID", staffSafetyRecord.safetyRatingID);
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID", staffSafetyRecord.staffID);
            return View(staffSafetyRecord);
        }

        // POST: StaffSafetyRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="staffSafetyRecord">The StaffSafetyRecords.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("staffID,safetyRatingID")] StaffSafetyRecord staffSafetyRecord)
        {
            if (id != staffSafetyRecord.safetyRatingID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffSafetyRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffSafetyRecordExists(staffSafetyRecord.safetyRatingID))
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
            ViewData["safetyRatingID"] = new SelectList(_context.SafetyRatings, "safetyRatingID", "safetyRatingID", staffSafetyRecord.safetyRatingID);
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID", staffSafetyRecord.staffID);
            return View(staffSafetyRecord);
        }

        // GET: StaffSafetyRecords/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="id2">The identifier.</param>
        public async Task<IActionResult> Delete(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }

            var staffSafetyRecord = await _context.StaffSafetyRecords
                .Include(s => s.SafetyRating)
                .Include(s => s.Staff)
                .FirstOrDefaultAsync(m => m.safetyRatingID == id && m.staffID == id2);
            if (staffSafetyRecord == null)
            {
                return NotFound();
            }

            return View(staffSafetyRecord);
        }

        // POST: StaffSafetyRecords/Delete/5
        /// <summary>
        /// Confirms the deletion of a Staff Safety Record
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="id2">The identifier.</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id, int? id2)
        {
            var staffSafetyRecord = await _context.StaffSafetyRecords.FindAsync(id, id2);
            _context.StaffSafetyRecords.Remove(staffSafetyRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Checks if the StaffSafetyRecords already exists
        /// </summary>
        /// <param name="id">The StaffSafetyRecords </param>
        private bool StaffSafetyRecordExists(int id)
        {
            return _context.StaffSafetyRecords.Any(e => e.safetyRatingID == id);
        }
    }
}
