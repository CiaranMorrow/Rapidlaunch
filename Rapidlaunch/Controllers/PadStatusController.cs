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
        private readonly ApplicationDbContext _context;

        public PadStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PadStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.PadStatuses.ToListAsync());
        }

        // GET: PadStatus/Details/5
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: PadStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var padStatus = await _context.PadStatuses.FindAsync(id);
            _context.PadStatuses.Remove(padStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadStatusExists(int id)
        {
            return _context.PadStatuses.Any(e => e.PadStatusID == id);
        }
    }
}
