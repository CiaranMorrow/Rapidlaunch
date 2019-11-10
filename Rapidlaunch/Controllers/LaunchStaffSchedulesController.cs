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
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchStaffSchedulesController"/> class
        /// </summary>

        public LaunchStaffSchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LaunchStaffSchedules
        /// <summary>
        /// Indexes the instance
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.LaunchStaffSchedules.Include(l => l.Launch).Include(l => l.staff); // linking the launch and staff connection 
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: LaunchStaffSchedules/Details/5
        /// <summary>
        /// Details the specified identifier
        /// </summary>
        /// <param name="id">The LaunchStaffSchedules </param>
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
        /// <summary>
        /// Creates the instance of LaunchStaffSchedule controller
        /// </summary>
        public IActionResult Create()
        {
            ViewData["launchID"] = new SelectList(_context.Launches, "LaunchID", "LaunchID");
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID");
            return View();
        }

        // POST: LaunchStaffSchedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the Launches
        /// </summary>
        /// <param name="launchStaffSchedule">The Launch</param>
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
        /// <summary>
        /// Edits the identifier
        /// </summary>
        /// <param name="id">The identifier for launchStaffSchedule </param>

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
        /// <summary>
        /// Edits the identifier
        /// </summary>
        /// <param name="id">The identifier  for the launchStaffSchedule    </param>
        /// <param name="launchStaffSchedule">The  launch </param>

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
        /// <summary>
        /// Deletes the identifier / record 
        /// </summary>
        /// <param name="id">The identifier record of launchStaffSchedule </param>
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
        /// <summary>
        /// Deletes the confirmed row / record
        /// </summary>
        /// <param name="id">The identifier / record of launch Staff Schedule Staff Schedule </param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var launchStaffSchedule = await _context.LaunchStaffSchedules.FindAsync(id);
            _context.LaunchStaffSchedules.Remove(launchStaffSchedule);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Checks if the launchStaffSchedule  already exists
        /// </summary>
        /// <param name="id">The launch Staff Schedule </param>
        private bool LaunchStaffScheduleExists(int id)
        {
            return _context.LaunchStaffSchedules.Any(e => e.LaunchStaffScheduleID == id);
        }
    }
}
