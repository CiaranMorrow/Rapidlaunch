using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rapidlaunch.Data;
using Rapidlaunch.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Controllers
{
    public class RocketTypesController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;
        /// <summary>
        /// Initializes a new instance of the <see cref="RocketTypesController"/> class
        /// </summary>
        /// <param name="context">The context.</param>

        public RocketTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RocketTypes
        /// <summary>
        /// Indexes this instance
        /// </summary>
        public async Task<IActionResult> Index()
        {
            return View(await _context.RocketTypes.ToListAsync());
        }

        // GET: RocketTypes/Details/5
        /// <summary>
        /// Details the identifier
        /// </summary>
        /// <param name="id">The identifier.</param>
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound(); // Throws a not found if id or details is empty 
            }

            var rocketType = await _context.RocketTypes
                .FirstOrDefaultAsync(m => m.rocketTypeID == id);
            if (rocketType == null)
            {
                return NotFound();
            }

            return View(rocketType);
        }

        // GET: RocketTypes/Create
        /// <summary>
        /// Creates this instance
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        // POST: RocketTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the rocket record as specified by the user.
        /// </summary>
        /// <param name="rocketType">The rocket type </param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("rocketTypeID,width,height,rocketignitor,rocketPropellant")] RocketType rocketType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rocketType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rocketType);
        }

        // GET: RocketTypes/Edit/5
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

            var rocketType = await _context.RocketTypes.FindAsync(id);
            if (rocketType == null)
            {
                return NotFound();
            }
            return View(rocketType);
        }

        // POST: RocketTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="rocketType">The rocket type .</param>
        /// dpesnt return anything
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("rocketTypeID,width,height,rocketignitor,rocketPropellant")] RocketType rocketType)
        {
            if (id != rocketType.rocketTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rocketType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RocketTypeExists(rocketType.rocketTypeID))
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
            return View(rocketType);
        }

        // GET: RocketTypes/Delete/5
        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// 
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rocketType = await _context.RocketTypes
                .FirstOrDefaultAsync(m => m.rocketTypeID == id);
            if (rocketType == null)
            {
                return NotFound();
            }

            return View(rocketType);
        }

        // POST: RocketTypes/Delete/5
        /// <summary>
        /// Confirms the deletion of a rocket tyoe 
        /// </summary>
        /// <param name="id">The identifier of the rockte type .</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rocketType = await _context.RocketTypes.FindAsync(id);
            _context.RocketTypes.Remove(rocketType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        /// <summary>
        /// Checks if the rocket type already exists
        /// </summary>
        /// <param name="id">The rockets typoes identifier </param>
        private bool RocketTypeExists(int id)
        {
            return _context.RocketTypes.Any(e => e.rocketTypeID == id);
        }
    }
}
