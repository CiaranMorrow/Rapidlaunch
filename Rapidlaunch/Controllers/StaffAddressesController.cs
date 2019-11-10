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
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="StaffAddressesController"/> class
        /// </summary>
        /// <param name="context">The context.</param

        public StaffAddressesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StaffAddresses
        /// <summary>
        /// Indexes this instance
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.StaffAddresses.Include(s => s.Address).Include(s => s.staff);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: StaffAddresses/Details/5 
        /// <summary>
        /// Details the specified identifier
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Throws a not found if id or details is empty 
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
        /// <summary>
        /// Creates this instance
        /// </summary>
        public IActionResult Create()
        {
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID");
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID");
            return View();
        }

        // POST: StaffAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the staff address record as specified by the user.
        /// </summary>
        /// <param name="staffAddress">The staff afddress.</param>
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
        /// <summary>
        /// Edits the specified identifier
        /// </summary>
        /// <param name="id">The identifier.</param>
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
        ///<summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="staffAddress">The StaffAddresses.</param>
        /// d0esnt return anything
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
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
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
        /// <summary>
        /// Confirms the deletion of a staff address
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id, int? id2)
        {
            var staffAddress = await _context.StaffAddresses.FindAsync( id2, id );
            _context.StaffAddresses.Remove(staffAddress);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks if the staff address already exists
        /// </summary>
        /// <param name="id">The Staff Addresses </param>
        private bool StaffAddressExists(int id)
        {
            return _context.StaffAddresses.Any(e => e.staffID == id);
        }
    }
}
