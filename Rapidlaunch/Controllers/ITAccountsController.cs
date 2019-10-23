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
    public class ITAccountsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ITAccountsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ITAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.ITAccounts.ToListAsync());
        }

        // GET: ITAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTAccount = await _context.ITAccounts
                .FirstOrDefaultAsync(m => m.ITAccountID == id);
            if (iTAccount == null)
            {
                return NotFound();
            }

            return View(iTAccount);
        }

        // GET: ITAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ITAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ITAccountID,itaccountTypeIdentID")] ITAccount iTAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iTAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iTAccount);
        }

        // GET: ITAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTAccount = await _context.ITAccounts.FindAsync(id);
            if (iTAccount == null)
            {
                return NotFound();
            }
            return View(iTAccount);
        }

        // POST: ITAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ITAccountID,itaccountTypeIdentID")] ITAccount iTAccount)
        {
            if (id != iTAccount.ITAccountID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iTAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ITAccountExists(iTAccount.ITAccountID))
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
            return View(iTAccount);
        }

        // GET: ITAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTAccount = await _context.ITAccounts
                .FirstOrDefaultAsync(m => m.ITAccountID == id);
            if (iTAccount == null)
            {
                return NotFound();
            }

            return View(iTAccount);
        }

        // POST: ITAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iTAccount = await _context.ITAccounts.FindAsync(id);
            _context.ITAccounts.Remove(iTAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ITAccountExists(int id)
        {
            return _context.ITAccounts.Any(e => e.ITAccountID == id);
        }
    }
}
