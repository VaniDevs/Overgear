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
    public class HeadgearController : Controller
    {
        private readonly OvergearContext _context;

        public HeadgearController(OvergearContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var results = from x in _context.Headgear
                          select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                results = results.Where(s => s.Description.Contains(searchString));
            }

            return View(await results.ToListAsync());
        }

        // GET: Headgear/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headgear = await _context.Headgear
                .FirstOrDefaultAsync(m => m.ID == id);
            if (headgear == null)
            {
                return NotFound();
            }

            return View(headgear);
        }

        // GET: Headgear/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Headgear/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Colour,Size,Quantity")] Headgear headgear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(headgear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(headgear);
        }

        // GET: Headgear/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headgear = await _context.Headgear.FindAsync(id);
            if (headgear == null)
            {
                return NotFound();
            }
            return View(headgear);
        }

        // POST: Headgear/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Colour,Size,Quantity")] Headgear headgear)
        {
            if (id != headgear.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(headgear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HeadgearExists(headgear.ID))
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
            return View(headgear);
        }

        // GET: Headgear/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var headgear = await _context.Headgear
                .FirstOrDefaultAsync(m => m.ID == id);
            if (headgear == null)
            {
                return NotFound();
            }

            return View(headgear);
        }

        // POST: Headgear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var headgear = await _context.Headgear.FindAsync(id);
            _context.Headgear.Remove(headgear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HeadgearExists(int id)
        {
            return _context.Headgear.Any(e => e.ID == id);
        }
    }
}
