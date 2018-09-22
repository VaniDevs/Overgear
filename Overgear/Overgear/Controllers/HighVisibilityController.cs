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
    public class HighVisibilityController : Controller
    {
        private readonly OvergearContext _context;

        public HighVisibilityController(OvergearContext context)
        {
            _context = context;
        }

        // GET: HighVisibility
        public async Task<IActionResult> Index()
        {
            return View(await _context.HighVisibility.ToListAsync());
        }

        // GET: HighVisibility/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highVisibility = await _context.HighVisibility
                .FirstOrDefaultAsync(m => m.ID == id);
            if (highVisibility == null)
            {
                return NotFound();
            }

            return View(highVisibility);
        }

        // GET: HighVisibility/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HighVisibility/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Size,Quantity")] HighVisibility highVisibility)
        {
            if (ModelState.IsValid)
            {
                _context.Add(highVisibility);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(highVisibility);
        }

        // GET: HighVisibility/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highVisibility = await _context.HighVisibility.FindAsync(id);
            if (highVisibility == null)
            {
                return NotFound();
            }
            return View(highVisibility);
        }

        // POST: HighVisibility/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Size,Quantity")] HighVisibility highVisibility)
        {
            if (id != highVisibility.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(highVisibility);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HighVisibilityExists(highVisibility.ID))
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
            return View(highVisibility);
        }

        // GET: HighVisibility/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var highVisibility = await _context.HighVisibility
                .FirstOrDefaultAsync(m => m.ID == id);
            if (highVisibility == null)
            {
                return NotFound();
            }

            return View(highVisibility);
        }

        // POST: HighVisibility/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var highVisibility = await _context.HighVisibility.FindAsync(id);
            _context.HighVisibility.Remove(highVisibility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HighVisibilityExists(int id)
        {
            return _context.HighVisibility.Any(e => e.ID == id);
        }
    }
}
