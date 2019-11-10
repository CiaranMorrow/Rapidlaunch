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
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="ITAccountTypesController"/> class
        /// </summary>
        public ITAccountTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ITAccountTypes
        /// <summary>
        /// Indexes the instance
        /// </summary>
        public async Task<IActionResult> Index()
        {
            return View(await _context.ITAccountTypes.ToListAsync());
        }

        // GET: ITAccountTypes/Details/5
        /// <summary>
        /// Details the specified identifier
        /// </summary>
        /// <param name="id">The ITAccountType </param>
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
        /// <summary>
        /// Creates the instance of ITAccountType controller
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        // POST: ITAccountTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the iTAccountType
        /// </summary>
        /// <param name="iTAccountType">The iTAccountType</param>
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
        /// <summary>
        /// Edits the identifier
        /// </summary>
        /// <param name="id">The identifier for iTAccountType </param>
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
        /// <summary>
        /// Edits the identifier
        /// </summary>
        /// <param name="id">The identifier  for the ITACcount    </param>
        /// <param name="iTAccounttype">The  ITACcount </param>

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
        /// <summary>
        /// Deletes the identifier / rec0rd 
        /// </summary>
        /// <param name="id">The identifier record of iTAccountType </param>
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
        /// <summary>
        /// Deletes the confirmed row / record
        /// </summary>
        /// <param name="id">The identifier / record of iTAccountType </param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var iTAccountType = await _context.ITAccountTypes.FindAsync(id);
            _context.ITAccountTypes.Remove(iTAccountType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Checks if the ITAccounttype  already exists
        /// </summary>
        /// <param name="id">The ITAccounttyoe </param>
        private bool ITAccountTypeExists(int id)
        {
            return _context.ITAccountTypes.Any(e => e.itAccountTypeID == id);
        }
    }
}
