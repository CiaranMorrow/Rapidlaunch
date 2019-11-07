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
            var applicationDbContext = _context.StaffAddresses.Include(s => s.Address).Include(s => s.staff);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StaffAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staffAddress = await _context.StaffAddresses
                .Include(s => s.Address)
                .Include(s => s.staff)
                .FirstOrDefaultAsync(m => m.staffID == id);
            if (staffAddress == null)
            {
                return NotFound();
            }

            return View(staffAddress);
        }

        // GET: StaffAddresses/Create
        public IActionResult Create()
        {
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID");
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID");
            return View();
        }

        // POST: StaffAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("staffID,AddressID")] StaffAddress staffAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staffAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", staffAddress.AddressID);
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID", staffAddress.staffID);
            return View(staffAddress);
        }

        // GET: StaffAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }

            var staffAddress = await _context.StaffAddresses.FindAsync(id, id2);
            if (staffAddress == null)
            {
                return NotFound();
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", staffAddress.AddressID);
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID", staffAddress.staffID);
            return View(staffAddress);
        }

        // POST: StaffAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("staffID,AddressID")] StaffAddress staffAddress)
        {
            if (id != staffAddress.staffID)
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
                    if (!StaffAddressExists(staffAddress.staffID))
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
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", staffAddress.AddressID);
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID", staffAddress.staffID);
            return View(staffAddress);
        }

        // GET: StaffAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }

            var staffAddress = await _context.StaffAddresses
                .Include(s => s.Address)
                .Include(s => s.staff)
                .FirstOrDefaultAsync(m => m.AddressID == id && m.staffID == id2);
            if (staffAddress == null)
            {
                return NotFound();
            }

            return View(staffAddress);
        }

        // POST: StaffAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id, int? id2)
        {
            var staffAddress = await _context.StaffAddresses.FindAsync( id2, id );
            _context.StaffAddresses.Remove(staffAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StaffAddressExists(int id)
        {
            return _context.StaffAddresses.Any(e => e.staffID == id);
        }
    }
}
