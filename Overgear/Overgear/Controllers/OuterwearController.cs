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
    public class OuterwearController : Controller
    {
        private readonly OvergearContext _context;

        public OuterwearController(OvergearContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var results = from x in _context.Outerwear
                        select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                results = results.Where(s => s.Description.Contains(searchString));
            }

            return View(await results.ToListAsync());
        }

        // GET: Outerwear/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outerwear = await _context.Outerwear
                .FirstOrDefaultAsync(m => m.ID == id);
            if (outerwear == null)
            {
                return NotFound();
            }

            return View(outerwear);
        }

        // GET: Outerwear/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Outerwear/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Colour,Size,Quantity")] Outerwear outerwear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(outerwear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(outerwear);
        }

        // GET: Outerwear/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outerwear = await _context.Outerwear.FindAsync(id);
            if (outerwear == null)
            {
                return NotFound();
            }
            return View(outerwear);
        }

        // POST: Outerwear/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Colour,Size,Quantity")] Outerwear outerwear)
        {
            if (id != outerwear.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(outerwear);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OuterwearExists(outerwear.ID))
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
            return View(outerwear);
        }

        // GET: Outerwear/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outerwear = await _context.Outerwear
                .FirstOrDefaultAsync(m => m.ID == id);
            if (outerwear == null)
            {
                return NotFound();
            }

            return View(outerwear);
        }

        // POST: Outerwear/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var outerwear = await _context.Outerwear.FindAsync(id);
            _context.Outerwear.Remove(outerwear);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OuterwearExists(int id)
        {
            return _context.Outerwear.Any(e => e.ID == id);
        }
    }
}
