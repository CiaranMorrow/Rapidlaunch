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
    public class RocketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RocketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rockets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rockets.ToListAsync());
        }

        // GET: Rockets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocket = await _context.Rockets
                .FirstOrDefaultAsync(m => m.RocketID == id);
            if (rocket == null)
            {
                return NotFound();
            }

            return View(rocket);
        }

        // GET: Rockets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rockets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RocketID,rocketName,rocketypeID")] Rocket rocket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rocket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rocket);
        }

        // GET: Rockets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocket = await _context.Rockets.FindAsync(id);
            if (rocket == null)
            {
                return NotFound();
            }
            return View(rocket);
        }

        // POST: Rockets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RocketID,rocketName,rocketypeID")] Rocket rocket)
        {
            if (id != rocket.RocketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rocket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RocketExists(rocket.RocketID))
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
            return View(rocket);
        }

        // GET: Rockets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocket = await _context.Rockets
                .FirstOrDefaultAsync(m => m.RocketID == id);
            if (rocket == null)
            {
                return NotFound();
            }

            return View(rocket);
        }

        // POST: Rockets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rocket = await _context.Rockets.FindAsync(id);
            _context.Rockets.Remove(rocket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RocketExists(int id)
        {
            return _context.Rockets.Any(e => e.RocketID == id);
        }
    }
}
