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
        private readonly ApplicationDbContext _context;

        public LaunchesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Launches
        public async Task<IActionResult> Index()
        {
            return View(await _context.Launches.ToListAsync());
        }

        // GET: Launches/Details/5
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: Launches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                return NotFound();
            }

            return View(launch);
        }

        // POST: Launches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var launch = await _context.Launches.FindAsync(id);
            _context.Launches.Remove(launch);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaunchExists(int id)
        {
            return _context.Launches.Any(e => e.LaunchID == id);
        }
    }
}
