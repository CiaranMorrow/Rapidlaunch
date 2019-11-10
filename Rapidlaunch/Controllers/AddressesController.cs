﻿using System;
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
    public class AddressesController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="AddressesController"/> class
        /// </summary>
        public AddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Addresses
        /// <summary>
        /// Indexes the instance
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Addresses.Include(a => a.country);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Addresses/Details/5
        /// <summary>
        /// Details the specified identifier
        /// </summary>
        /// <param name="id">The address</param>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.country)
                .FirstOrDefaultAsync(m => m.AddressID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // GET: Addresses/Create
        /// <summary>
        /// Creates the instance.
        /// </summary>
        public IActionResult Create()
        {
            ViewData["countryID"] = new SelectList(_context.Countries, "CountryID", "CountryID");
            return View();
        }

        // POST: Addresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the address
        /// </summary>
        /// <param name="address">The address</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AddressID,addressLine1,addressLine2,addressLine3,countryID,postCode")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["countryID"] = new SelectList(_context.Countries, "CountryID", "CountryID", address.countryID);
            return View(address);
        }

        // GET: Addresses/Edit/5
        /// <summary>
        /// Edits the identifier
        /// </summary>
        /// <param name="id">The identifier</param>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return NotFound();
            }
            ViewData["countryID"] = new SelectList(_context.Countries, "CountryID", "CountryID", address.countryID);
            return View(address);
        }

        // POST: Addresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the identifier
        /// </summary>
        /// <param name="id">The identifier of address       </param>
        /// <param name="address">The address   </param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AddressID,addressLine1,addressLine2,addressLine3,countryID,postCode")] Address address)
        {
            if (id != address.AddressID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(address);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddressExists(address.AddressID))
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
            ViewData["countryID"] = new SelectList(_context.Countries, "CountryID", "CountryID", address.countryID);
            return View(address);
        }

        // GET: Addresses/Delete/5
        /// <summary>
        /// Deletes the identifier / recprd 
        /// </summary>
        /// <param name="id">The identifierrecord of address </param>


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var address = await _context.Addresses
                .Include(a => a.country)
                .FirstOrDefaultAsync(m => m.AddressID == id);
            if (address == null)
            {
                return NotFound();
            }

            return View(address);
        }

        // POST: Addresses/Delete/5
        /// <summary>
        /// Deletes the confirmed row / record
        /// </summary>
        /// <param name="id">The identifier / record of address</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Checks if the address already exists
        /// </summary>
        /// <param name="id">The address.</param>

        private bool AddressExists(int id)
        {
            return _context.Addresses.Any(e => e.AddressID == id);
        }
    }
}
