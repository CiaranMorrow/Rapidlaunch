using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Rapidlaunch.Data;
using Rapidlaunch.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Rapidlaunch.Controllers
{
    public class RocketsController : Controller
    {
        /// <summary>
        /// The context
        /// </summary>
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="RocketsController"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public RocketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rockets
        /// <summary>
        /// Indexes this instance
        /// </summary>
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rockets.ToListAsync());
        }

        // GET: Rockets/Details/5
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

            var rocket = await _context.Rockets
                .FirstOrDefaultAsync(m => m.RocketID == id);
            if (rocket == null)
            {
                return NotFound();
            }

            return View(rocket);
        }

        // GET: Rockets/Create
        /// <summary>
        /// Creates this instance
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rockets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Creates the rocket record as specified by the user.
        /// </summary>
        /// <param name="rocket">The rocket.</param>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RocketID,rocketName,rocketypeID")] Rocket rocket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rocket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rocket);
        }

        // GET: Rockets/Edit/5

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

            var rocket = await _context.Rockets.FindAsync(id);
            if (rocket == null)
            {
                return NotFound();
            }
            return View(rocket);
        }

        // POST: Rockets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="rocket">The rocket.</param>
        /// dpesnt return anything
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RocketID,rocketName,rocketypeID")] Rocket rocket)
        {
            if (id != rocket.RocketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rocket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RocketExists(rocket.RocketID))
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
            return View(rocket);
        }

        // GET: Rockets/Delete/5
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

            var rocket = await _context.Rockets
                .FirstOrDefaultAsync(m => m.RocketID == id);
            if (rocket == null)
            {
                return NotFound();
            }

            return View(rocket);
        }

        // POST: Rockets/Delete/5
        /// <summary>
        /// Confirms the deletion of a rocket
        /// </summary>
        /// <param name="id">The identifier.</param>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rocket = await _context.Rockets.FindAsync(id);
            _context.Rockets.Remove(rocket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Checks if the rocket already exists
        /// </summary>
        /// <param name="id">The rockets </param>
        private bool RocketExists(int id)
        {
            return _context.Rockets.Any(e => e.RocketID == id);
        }
    }
}
