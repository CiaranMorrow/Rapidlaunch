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
    public class LaunchStaffSchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LaunchStaffSchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LaunchStaffSchedules
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LaunchStaffSchedules.Include(l => l.Launch).Include(l => l.staff);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LaunchStaffSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launchStaffSchedule = await _context.LaunchStaffSchedules
                .Include(l => l.Launch)
                .Include(l => l.staff)
                .FirstOrDefaultAsync(m => m.LaunchStaffScheduleID == id);
            if (launchStaffSchedule == null)
            {
                return NotFound();
            }

            return View(launchStaffSchedule);
        }

        // GET: LaunchStaffSchedules/Create
        public IActionResult Create()
        {
            ViewData["launchID"] = new SelectList(_context.Launches, "LaunchID", "LaunchID");
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID");
            return View();
        }

        // POST: LaunchStaffSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LaunchStaffScheduleID,launchID,staffID")] LaunchStaffSchedule launchStaffSchedule)
        {
            if (ModelState.IsValid)
            {
                _context.Add(launchStaffSchedule);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["launchID"] = new SelectList(_context.Launches, "LaunchID", "LaunchID", launchStaffSchedule.launchID);
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID", launchStaffSchedule.staffID);
            return View(launchStaffSchedule);
        }

        // GET: LaunchStaffSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launchStaffSchedule = await _context.LaunchStaffSchedules.FindAsync(id);
            if (launchStaffSchedule == null)
            {
                return NotFound();
            }
            ViewData["launchID"] = new SelectList(_context.Launches, "LaunchID", "LaunchID", launchStaffSchedule.launchID);
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID", launchStaffSchedule.staffID);
            return View(launchStaffSchedule);
        }

        // POST: LaunchStaffSchedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LaunchStaffScheduleID,launchID,staffID")] LaunchStaffSchedule launchStaffSchedule)
        {
            if (id != launchStaffSchedule.LaunchStaffScheduleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(launchStaffSchedule);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaunchStaffScheduleExists(launchStaffSchedule.LaunchStaffScheduleID))
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
            ViewData["launchID"] = new SelectList(_context.Launches, "LaunchID", "LaunchID", launchStaffSchedule.launchID);
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID", launchStaffSchedule.staffID);
            return View(launchStaffSchedule);
        }

        // GET: LaunchStaffSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launchStaffSchedule = await _context.LaunchStaffSchedules
                .Include(l => l.Launch)
                .Include(l => l.staff)
                .FirstOrDefaultAsync(m => m.LaunchStaffScheduleID == id);
            if (launchStaffSchedule == null)
            {
                return NotFound();
            }

            return View(launchStaffSchedule);
        }

        // POST: LaunchStaffSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var launchStaffSchedule = await _context.LaunchStaffSchedules.FindAsync(id);
            _context.LaunchStaffSchedules.Remove(launchStaffSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaunchStaffScheduleExists(int id)
        {
            return _context.LaunchStaffSchedules.Any(e => e.LaunchStaffScheduleID == id);
        }
    }
}
