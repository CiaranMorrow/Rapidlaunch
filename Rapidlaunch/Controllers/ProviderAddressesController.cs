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
    public class ProviderAddressesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProviderAddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProviderAddresses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProviderAddresses.Include(p => p.Address).Include(p => p.Provider);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProviderAddresses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var providerAddress = await _context.ProviderAddresses
                .Include(p => p.Address)
                .Include(p => p.Provider)
                .FirstOrDefaultAsync(m => m.ProviderID == id);
            if (providerAddress == null)
            {
                return NotFound();
            }

            return View(providerAddress);
        }

        // GET: ProviderAddresses/Create
        public IActionResult Create()
        {
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID");
            ViewData["ProviderID"] = new SelectList(_context.Providers, "ProviderID", "ProviderID");
            return View();
        }

        // POST: ProviderAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProviderID,AddressID")] ProviderAddress providerAddress)
        {
            if (ModelState.IsValid)
            {
                _context.Add(providerAddress);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", providerAddress.AddressID);
            ViewData["ProviderID"] = new SelectList(_context.Providers, "ProviderID", "ProviderID", providerAddress.ProviderID);
            return View(providerAddress);
        }

        // GET: ProviderAddresses/Edit/5
        public async Task<IActionResult> Edit(int? id, int? id2)
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }

            var providerAddress = await _context.ProviderAddresses.FindAsync(id, id2);
            if (providerAddress == null)
            {
                return NotFound();
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", providerAddress.AddressID);
            ViewData["ProviderID"] = new SelectList(_context.Providers, "ProviderID", "ProviderID", providerAddress.ProviderID);
            return View(providerAddress);
        }

        // POST: ProviderAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProviderID,AddressID")] ProviderAddress providerAddress)
        {
            if (id != providerAddress.ProviderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(providerAddress);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProviderAddressExists(providerAddress.ProviderID))
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
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", providerAddress.AddressID);
            ViewData["ProviderID"] = new SelectList(_context.Providers, "ProviderID", "ProviderID", providerAddress.ProviderID);
            return View(providerAddress);
        }

        // GET: ProviderAddresses/Delete/5
        public async Task<IActionResult> Delete(int? id, int? id2  )
        {
            if (id == null || id2 == null)
            {
                return NotFound();
            }

            var providerAddress = await _context.ProviderAddresses
                .Include(p => p.Address)
                .Include(p => p.Provider)
                .FirstOrDefaultAsync(m => m.ProviderID == id && m.ProviderID == id2);
            if (providerAddress == null)
            {
                return NotFound();
            }

            return View(providerAddress);
        }

        // POST: ProviderAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id, int? id2)
        {
            var providerAddress = await _context.ProviderAddresses.FindAsync(id2, id);
            _context.ProviderAddresses.Remove(providerAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProviderAddressExists(int id)
        {
            return _context.ProviderAddresses.Any(e => e.ProviderID == id);
        }
    }
}
