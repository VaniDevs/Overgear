using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Overgear.Models;

namespace Overgear.Controllers
{
    public class BootsController : Controller
    {
        private readonly OvergearContext _context;

        public BootsController(OvergearContext context)
        {
            _context = context;
        }

        // GET: Boots
        public async Task<IActionResult> Index()
        {
            return View(await _context.Boot.ToListAsync());
        }

        // GET: Boots/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boot = await _context.Boot
                .FirstOrDefaultAsync(m => m.ID == id);
            if (boot == null)
            {
                return NotFound();
            }

            return View(boot);
        }

        // GET: Boots/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Boots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Size,Quantity")] Boot boot)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boot);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boot);
        }

        // GET: Boots/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boot = await _context.Boot.FindAsync(id);
            if (boot == null)
            {
                return NotFound();
            }
            return View(boot);
        }

        // POST: Boots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Size,Quantity")] Boot boot)
        {
            if (id != boot.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boot);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BootExists(boot.ID))
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
            return View(boot);
        }

        // GET: Boots/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boot = await _context.Boot
                .FirstOrDefaultAsync(m => m.ID == id);
            if (boot == null)
            {
                return NotFound();
            }

            return View(boot);
        }

        // POST: Boots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var boot = await _context.Boot.FindAsync(id);
            _context.Boot.Remove(boot);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BootExists(int id)
        {
            return _context.Boot.Any(e => e.ID == id);
        }

        // Just return a list of states - in a real-world application this would call
        // into data access layer to retrieve states from a database.
        private IEnumerable<int> GetAllSizes()
        {
            return new List<int>
            {
                5, 6, 7, 8, 9,
                10, 11, 12, 13
            };
        }
    }
}
