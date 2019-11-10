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
    public class PadStatusController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="PadStatusController"/> class
        /// </summary>
        public PadStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PadStatus
        /// <summary>
        /// Indexes the instance
        /// </summary>
        public async Task<IActionResult> Index()
        {
            return View(await _context.PadStatuses.ToListAsync());
        }

        // GET: PadStatus/Details/5
        /// <summary>
        /// Details the specified identifier
        /// </summary>
        /// <param name="id">The Pad Status </param>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padStatus = await _context.PadStatuses
                .FirstOrDefaultAsync(m => m.PadStatusID == id);
            if (padStatus == null)
            {
                return NotFound();
            }

            return View(padStatus);
        }

        // GET: PadStatus/Create
        /// <summary>
        /// Creates the instance of Pad Status controller
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        // POST: PadStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the pad Status
        /// </summary>
        /// <param name="padStatus">The pad Status</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PadStatusID,padStatus")] PadStatus padStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(padStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(padStatus);
        }

        // GET: PadStatus/Edit/5
        /// <summary>
        /// Edits the identifier
        /// </summary>
        /// <param name="id">The identifier for Pad Status </param>

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padStatus = await _context.PadStatuses.FindAsync(id);
            if (padStatus == null)
            {
                return NotFound();
            }
            return View(padStatus);
        }

        // POST: PadStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the identifier
        /// </summary>
        /// <param name="id">The identifier  for the padstatus    </param>
        /// <param name="padStatus">The  launch </param>

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PadStatusID,padStatus")] PadStatus padStatus)
        {
            if (id != padStatus.PadStatusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(padStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadStatusExists(padStatus.PadStatusID))
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
            return View(padStatus);
        }

        // GET: PadStatus/Delete/5
        /// <summary>
        /// Deletes the identifier / record 
        /// </summary>
        /// <param name="id">The identifier record of pad statuses </param>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padStatus = await _context.PadStatuses
                .FirstOrDefaultAsync(m => m.PadStatusID == id);
            if (padStatus == null)
            {
                return NotFound();
            }

            return View(padStatus);
        }

        // POST: PadStatus/Delete/5
        /// <summary>
        /// Deletes the confirmed row / record
        /// </summary>
        /// <param name="id">The identifier / record of Pad status </param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var padStatus = await _context.PadStatuses.FindAsync(id);
            _context.PadStatuses.Remove(padStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Checks if the PAd Status  already exists
        /// </summary>
        /// <param name="id">Th e PAd Status </param>
        private bool PadStatusExists(int id)
        {
            return _context.PadStatuses.Any(e => e.PadStatusID == id);
        }
    }
}
