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
        private readonly ApplicationDbContext _context;

        public StaffSafetyRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StaffSafetyRecords
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StaffSafetyRecords.Include(s => s.SafetyRating).Include(s => s.rocketType);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StaffSafetyRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffSafetyRecord = await _context.StaffSafetyRecords
                .Include(s => s.SafetyRating)
                .Include(s => s.rocketType)
                .FirstOrDefaultAsync(m => m.safetyRatingID == id);
            if (staffSafetyRecord == null)
            {
                return NotFound();
            }

            return View(staffSafetyRecord);
        }

        // GET: StaffSafetyRecords/Create
        public IActionResult Create()
        {
            ViewData["staffID"] = new SelectList(_context.SafetyRatings, "staffID", "staffID");
            ViewData["safetyRatingID"] = new SelectList(_context.SafetyRatings, "safetyRatingID", "safetyRatingID");
            ViewData["rocketTypeID"] = new SelectList(_context.RocketTypes, "rocketTypeID", "rocketTypeID");
            return View();
        }

        // POST: StaffSafetyRecords/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("staffID,safetyRatingID,rocketTypeID")] StaffSafetyRecord staffSafetyRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffSafetyRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["safetyRatingID"] = new SelectList(_context.SafetyRatings, "safetyRatingID", "safetyRatingID", staffSafetyRecord.safetyRatingID);
            ViewData["rocketTypeID"] = new SelectList(_context.RocketTypes, "rocketTypeID", "rocketTypeID", staffSafetyRecord.rocketTypeID);
            return View(staffSafetyRecord);
        }

        // GET: StaffSafetyRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffSafetyRecord = await _context.StaffSafetyRecords.FindAsync(id);
            if (staffSafetyRecord == null)
            {
                return NotFound();
            }
            ViewData["safetyRatingID"] = new SelectList(_context.SafetyRatings, "safetyRatingID", "safetyRatingID", staffSafetyRecord.safetyRatingID);
            ViewData["rocketTypeID"] = new SelectList(_context.RocketTypes, "rocketTypeID", "rocketTypeID", staffSafetyRecord.rocketTypeID);
            return View(staffSafetyRecord);
        }

        // POST: StaffSafetyRecords/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("staffID,safetyRatingID,rocketTypeID")] StaffSafetyRecord staffSafetyRecord)
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
            ViewData["rocketTypeID"] = new SelectList(_context.RocketTypes, "rocketTypeID", "rocketTypeID", staffSafetyRecord.rocketTypeID);
            return View(staffSafetyRecord);
        }

        // GET: StaffSafetyRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffSafetyRecord = await _context.StaffSafetyRecords
                .Include(s => s.SafetyRating)
                .Include(s => s.rocketType)
                .FirstOrDefaultAsync(m => m.safetyRatingID == id);
            if (staffSafetyRecord == null)
            {
                return NotFound();
            }

            return View(staffSafetyRecord);
        }

        // POST: StaffSafetyRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffSafetyRecord = await _context.StaffSafetyRecords.FindAsync(id);
            _context.StaffSafetyRecords.Remove(staffSafetyRecord);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffSafetyRecordExists(int id)
        {
            return _context.StaffSafetyRecords.Any(e => e.safetyRatingID == id);
        }
    }
}
