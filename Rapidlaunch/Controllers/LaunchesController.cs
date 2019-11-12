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
    public class LaunchesController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="LaunchesController"/> class
        /// </summary>

        public LaunchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Launches
        /// <summary>
        /// Indexes the instance
        /// </summary>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Launches.ToListAsync());
        }

        // GET: Launches/Details/5
        /// <summary>
        /// Details the specified identifier
        /// </summary>
        /// <param name="id">The Launches </param>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launch = await _context.Launches
                .FirstOrDefaultAsync(m => m.LaunchID == id);
            if (launch == null)
            {
                return NotFound();
            }

            return View(launch);
        }

        // GET: Launches/Create
        /// <summary>
        /// Creates the instance of LaunchesController controller
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Launches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        /// <summary>
        /// Creates the Launches
        /// </summary>
        /// <param name="launch">The Launch</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LaunchID,providerIdent,launchDate,launchName,padStatusIdenet,rocketIdentID")] Launch launch)
        {
            if (ModelState.IsValid)
            {
                _context.Add(launch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(launch);
        }

        // GET: Launches/Edit/5
        /// <summary>
        /// Edits the identifier
        /// </summary>
        /// <param name="id">The identifier for launch </param>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launch = await _context.Launches.FindAsync(id);
            if (launch == null)
            {
                return NotFound();
            }
            return View(launch);
        }

        // POST: Launches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the identifier
        /// </summary>
        /// <param name="id">The identifier  for the launch    </param>
        /// <param name="launch">The  launch </param>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LaunchID,providerIdent,launchDate,launchName,padStatusIdenet,rocketIdentID")] Launch launch)
        {
            if (id != launch.LaunchID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(launch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaunchExists(launch.LaunchID))
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
            return View(launch);
        }

        // GET: Launches/Delete/5
        /// <summary>
        /// Deletes the identifier / record 
        /// </summary>
        /// <param name="id">The identifier record of launch </param>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var launch = await _context.Launches
                .FirstOrDefaultAsync(m => m.LaunchID == id);
            if (launch == null)
            {
                return NotFound(); // checks if file is in db
            }

            return View(launch);


        }

        // POST: Launches/Delete/5
        /// <summary>
        /// Deletes the confirmed row / record
        /// </summary>
        /// <param name="id">The identifier / record of laucnh </param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var launch = await _context.Launches.FindAsync(id);
            _context.Launches.Remove(launch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks if the launchStaffSchedule  already exists
        /// </summary>
        /// <param name="id">The launch </param>
        private bool LaunchExists(int id)
        {
            return _context.Launches.Any(e => e.LaunchID == id);
        }
    }
}
