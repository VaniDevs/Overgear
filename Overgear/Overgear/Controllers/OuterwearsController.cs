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
    public class OuterwearsController : Controller
    {
        private readonly OvergearContext _context;

        public OuterwearsController(OvergearContext context)
        {
            _context = context;
        }

        // GET: Outerwears
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.DescSortParm = String.IsNullOrEmpty(sortOrder) ? "desc" : "";
            ViewBag.ColSortParm = String.IsNullOrEmpty(sortOrder) ? "col" : "";
            ViewBag.SizeSortParm = String.IsNullOrEmpty(sortOrder) ? "size" : "";
            ViewBag.QuanSortParm = String.IsNullOrEmpty(sortOrder) ? "quan" : "";

            var results = from x in _context.Outerwear
                          select x;

            switch (sortOrder)
            {
                case "desc":
                    results = results.OrderByDescending(s => s.Description);
                    break;
                case "col":
                    results = results.OrderBy(s => s.Colour);
                    break;
                case "size":
                    results = results.OrderBy(s => s.Size);
                    break;
                case "quan":
                    results = results.OrderBy(s => s.Quantity);
                    break;
                default:
                    results = results.OrderBy(s => s.Description);
                    break;
            }
            return View(await results.ToListAsync());
        }

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Outerwear.ToListAsync());
        //}

        // GET: Outerwears/Details/5
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

        // GET: Outerwears/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Outerwears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Size,Colour,Quantity")] Outerwear outerwear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(outerwear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(outerwear);
        }

        // GET: Outerwears/Edit/5
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

        // POST: Outerwears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Size,Colour,Quantity")] Outerwear outerwear)
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

        // GET: Outerwears/Delete/5
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

        // POST: Outerwears/Delete/5
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
