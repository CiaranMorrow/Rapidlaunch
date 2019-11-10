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
    public class StaffsController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="StaffsController"/> class
        /// </summary>
        /// <param name="context">The context.</param>

        public StaffsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Staffs
        /// <summary>
        /// Indexes this instance
        /// </summary>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Staffs.ToListAsync());
        }

        // GET: Staffs/Details/5
        /// <summary>
        /// Details the specified identifier
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .FirstOrDefaultAsync(m => m.staffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // GET: Staffs/Create
        /// <summary>
        /// Creates this instance
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Staffs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the Staff record as specified by the user.
        /// </summary>
        /// <param name="staff">The staff </param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("staffID,roleIdentID,staffTel,firstNameIdent,lastNameIdent,staffEmail,itAccountIdentID")] Staff staff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(staff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(staff);
        }

        // GET: Staffs/Edit/5
        /// <summary>
        /// Edits the specified identifier
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs.FindAsync(id);
            if (staff == null)
            {
                return NotFound();
            }
            return View(staff);
        }

        // POST: Staffs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="staff">The staff.</param>
        /// dpesnt return anything
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("staffID,roleIdentID,staffTel,firstNameIdent,lastNameIdent,staffEmail,itAccountIdentID")] Staff staff)
        {
            if (id != staff.staffID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(staff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.staffID))
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
            return View(staff);
        }

        // GET: Staffs/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .FirstOrDefaultAsync(m => m.staffID == id);
            if (staff == null)
            {
                return NotFound();
            }

            return View(staff);
        }

        // POST: Staffs/Delete/5
        /// <summary>
        /// Confirms the deletion of a staff
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var staff = await _context.Staffs.FindAsync(id);
            _context.Staffs.Remove(staff);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// Checks if the staff already exists
        /// </summary>
        /// <param name="id">The staff </param>

        private bool StaffExists(int id)
        {
            return _context.Staffs.Any(e => e.staffID == id);
        }
    }
}
