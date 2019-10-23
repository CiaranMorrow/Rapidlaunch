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
    public class ITAccountTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ITAccountTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ITAccountTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ITAccountTypes.ToListAsync());
        }

        // GET: ITAccountTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTAccountType = await _context.ITAccountTypes
                .FirstOrDefaultAsync(m => m.itAccountTypeID == id);
            if (iTAccountType == null)
            {
                return NotFound();
            }

            return View(iTAccountType);
        }

        // GET: ITAccountTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ITAccountTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("itAccountTypeID,authorisationLevel")] ITAccountType iTAccountType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(iTAccountType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(iTAccountType);
        }

        // GET: ITAccountTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTAccountType = await _context.ITAccountTypes.FindAsync(id);
            if (iTAccountType == null)
            {
                return NotFound();
            }
            return View(iTAccountType);
        }

        // POST: ITAccountTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("itAccountTypeID,authorisationLevel")] ITAccountType iTAccountType)
        {
            if (id != iTAccountType.itAccountTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(iTAccountType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ITAccountTypeExists(iTAccountType.itAccountTypeID))
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
            return View(iTAccountType);
        }

        // GET: ITAccountTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var iTAccountType = await _context.ITAccountTypes
                .FirstOrDefaultAsync(m => m.itAccountTypeID == id);
            if (iTAccountType == null)
            {
                return NotFound();
            }

            return View(iTAccountType);
        }

        // POST: ITAccountTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iTAccountType = await _context.ITAccountTypes.FindAsync(id);
            _context.ITAccountTypes.Remove(iTAccountType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ITAccountTypeExists(int id)
        {
            return _context.ITAccountTypes.Any(e => e.itAccountTypeID == id);
        }
    }
}
