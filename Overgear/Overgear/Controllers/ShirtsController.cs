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
    public class ShirtsController : Controller
    {
        private readonly OvergearContext _context;

        public ShirtsController(OvergearContext context)
        {
            _context = context;
        }

        // GET: Shirts
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Shirt.ToListAsync());
        //}
        
        public async Task<IActionResult> Index(string searchString)
        {
            var shirts = from x in _context.Shirt
                         select x;
            if (!String.IsNullOrEmpty(searchString))
            {
                shirts = shirts.Where(s => s.Description.Contains(searchString));
            }

            return View(await shirts.ToListAsync());
        }

        // GET: Shirts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shirt = await _context.Shirt
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shirt == null)
            {
                return NotFound();
            }

            return View(shirt);
        }

        // GET: Shirts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shirts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Size,Quantity")] Shirt shirt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shirt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shirt);
        }

        // GET: Shirts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shirt = await _context.Shirt.FindAsync(id);
            if (shirt == null)
            {
                return NotFound();
            }
            return View(shirt);
        }

        // POST: Shirts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Size,Quantity")] Shirt shirt)
        {
            if (id != shirt.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shirt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShirtExists(shirt.ID))
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
            return View(shirt);
        }

        // GET: Shirts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shirt = await _context.Shirt
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shirt == null)
            {
                return NotFound();
            }

            return View(shirt);
        }

        // POST: Shirts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shirt = await _context.Shirt.FindAsync(id);
            _context.Shirt.Remove(shirt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShirtExists(int id)
        {
            return _context.Shirt.Any(e => e.ID == id);
        }
    }
}
