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
        private readonly ApplicationDbContext _context;

        public RocketTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: RocketTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.RocketTypes.ToListAsync());
        }

        // GET: RocketTypes/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: RocketTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RocketTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rocketType = await _context.RocketTypes.FindAsync(id);
            _context.RocketTypes.Remove(rocketType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RocketTypeExists(int id)
        {
            return _context.RocketTypes.Any(e => e.rocketTypeID == id);
        }
    }
}
