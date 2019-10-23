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
    public class StaffAddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StaffAddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StaffAddresses
        public async Task<IActionResult> Index()
        {
            return View(await _context.StaffAddresses.ToListAsync());
        }

        // GET: StaffAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffAddress = await _context.StaffAddresses
                .FirstOrDefaultAsync(m => m.staffAdrressID == id);
            if (staffAddress == null)
            {
                return NotFound();
            }

            return View(staffAddress);
        }

        // GET: StaffAddresses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StaffAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("staffAdrressID,staffIdentID")] StaffAddress staffAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staffAddress);
        }

        // GET: StaffAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffAddress = await _context.StaffAddresses.FindAsync(id);
            if (staffAddress == null)
            {
                return NotFound();
            }
            return View(staffAddress);
        }

        // POST: StaffAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("staffAdrressID,staffIdentID")] StaffAddress staffAddress)
        {
            if (id != staffAddress.staffAdrressID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staffAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffAddressExists(staffAddress.staffAdrressID))
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
            return View(staffAddress);
        }

        // GET: StaffAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffAddress = await _context.StaffAddresses
                .FirstOrDefaultAsync(m => m.staffAdrressID == id);
            if (staffAddress == null)
            {
                return NotFound();
            }

            return View(staffAddress);
        }

        // POST: StaffAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staffAddress = await _context.StaffAddresses.FindAsync(id);
            _context.StaffAddresses.Remove(staffAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffAddressExists(int id)
        {
            return _context.StaffAddresses.Any(e => e.staffAdrressID == id);
        }
    }
}
