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
            var applicationDbContext = _context.StaffAddresses.Include(s => s.Address).Include(s => s.staff); // compound key
            return View(await applicationDbContext.ToListAsync()); // awaiting and will not go before recieveing the application context 
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
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID"); // compound key 
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID"); // compound key requires the two options to select from
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
        public async Task<IActionResult> Create([Bind("staffID,AddressID")] StaffAddress staffAddress)  // creating the compound key 
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
            if (id == null || id2 == null) // OR statement saying it need to be both there
            {
                return NotFound();
            }

            var staffAddress = await _context.StaffAddresses.FindAsync(id, id2);
            if (staffAddress == null)
            {
                return NotFound();  //returning the 404
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", staffAddress.AddressID); // editing the two options 
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("staffID,AddressID")] StaffAddress staffAddress) // Binding the id to the staffaddress so it can be recalled 
        {
            if (id != staffAddress.staffID) //it makes sure that the ID is related to the staff address 
            {
                return NotFound(); // throws an error if it isnt 
            }

            if (ModelState.IsValid) // if it is correctly binded then carry on to this 
            {
                try
                {
                    _context.Update(staffAddress); //updates the database 
                    await _context.SaveChangesAsync(); //wait until it comes back 
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffAddressExists(staffAddress.staffID)) // if it already exists within the db then return an error 
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index)); // if it works well - go back to the index 
            }
            ViewData["AddressID"] = new SelectList(_context.Addresses, "AddressID", "AddressID", staffAddress.AddressID);
            ViewData["staffID"] = new SelectList(_context.Staffs, "staffID", "staffID", staffAddress.staffID);
            return View(staffAddress);
        }

        // GET: StaffAddresses/Delete/5
        /// <summary>
        /// Deletes the specified identifiers (id and id2) 
        /// </summary>
        public async Task<IActionResult> Delete(int? id, int? id2)
        {
            if (id == null || id2 == null) // checks if the both of them are populated bedore deleting 
            {
                return NotFound();
            }

            var staffAddress = await _context.StaffAddresses
                .Include(s => s.Address)
                .Include(s => s.staff)
                .FirstOrDefaultAsync(m => m.AddressID == id && m.staffID == id2); // deleting the two records with the and statement
            if (staffAddress == null) // checks that there is something there to delete
            {
                return NotFound(); // returns error where it hasnt been deleted 
            }

            return View(staffAddress); 
        }

        // POST: StaffAddresses/Delete/5
        /// <summary>
        /// Confirms the deletion of a staff address
        /// </summary>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id, int? id2) // deleting the compounded keys 
        {
            var staffAddress = await _context.StaffAddresses.FindAsync( id2, id ); // gets the data from the db 
            _context.StaffAddresses.Remove(staffAddress); // deletes the actual record 
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); // once completed takes back tp the home paee 
        }

        /// <summary>
        /// Checks if the staff address already exists
        /// </summary>
        /// <param name="id">The Staff Addresses </param>
        private bool StaffAddressExists(int id) // nice little method for you there
        {
            return _context.StaffAddresses.Any(e => e.staffID == id);
        }
    }
}
