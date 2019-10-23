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
    public class ProviderContactsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProviderContactsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProviderContacts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProviderContacts.Include(p => p.provider);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProviderContacts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var providerContact = await _context.ProviderContacts
                .Include(p => p.provider)
                .FirstOrDefaultAsync(m => m.ProviderContactID == id);
            if (providerContact == null)
            {
                return NotFound();
            }

            return View(providerContact);
        }

        // GET: ProviderContacts/Create
        public IActionResult Create()
        {
            ViewData["providerID"] = new SelectList(_context.Providers, "ProviderID", "ProviderID");
            return View();
        }

        // POST: ProviderContacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProviderContactID,providerID,firstName,lastName,contactEmail,roleIdentID,contactTelNum")] ProviderContact providerContact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(providerContact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["providerID"] = new SelectList(_context.Providers, "ProviderID", "ProviderID", providerContact.providerID);
            return View(providerContact);
        }

        // GET: ProviderContacts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var providerContact = await _context.ProviderContacts.FindAsync(id);
            if (providerContact == null)
            {
                return NotFound();
            }
            ViewData["providerID"] = new SelectList(_context.Providers, "ProviderID", "ProviderID", providerContact.providerID);
            return View(providerContact);
        }

        // POST: ProviderContacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProviderContactID,providerID,firstName,lastName,contactEmail,roleIdentID,contactTelNum")] ProviderContact providerContact)
        {
            if (id != providerContact.ProviderContactID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(providerContact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProviderContactExists(providerContact.ProviderContactID))
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
            ViewData["providerID"] = new SelectList(_context.Providers, "ProviderID", "ProviderID", providerContact.providerID);
            return View(providerContact);
        }

        // GET: ProviderContacts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var providerContact = await _context.ProviderContacts
                .Include(p => p.provider)
                .FirstOrDefaultAsync(m => m.ProviderContactID == id);
            if (providerContact == null)
            {
                return NotFound();
            }

            return View(providerContact);
        }

        // POST: ProviderContacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var providerContact = await _context.ProviderContacts.FindAsync(id);
            _context.ProviderContacts.Remove(providerContact);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProviderContactExists(int id)
        {
            return _context.ProviderContacts.Any(e => e.ProviderContactID == id);
        }
    }
}
