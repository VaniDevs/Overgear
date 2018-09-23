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
    public class HeadgearsController : Controller
    {
        private readonly OvergearContext _context;

        public HeadgearsController(OvergearContext context)
        {
            _context = context;
        }

        // GET: Headgears
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.DescSortParm = String.IsNullOrEmpty(sortOrder) ? "desc" : "";
            ViewBag.ColSortParm = String.IsNullOrEmpty(sortOrder) ? "col" : "";
            ViewBag.QuanSortParm = String.IsNullOrEmpty(sortOrder) ? "quan" : "";

            var results = from x in _context.Headgear
                          select x;

            switch (sortOrder)
            {
                case "desc":
                    results = results.OrderByDescending(s => s.Description);
                    break;
                case "col":
                    results = results.OrderBy(s => s.Colour);
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
        //    return View(await _context.Headgear.ToListAsync());
        //}

        // GET: Headgears/Details/5
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

        // GET: Headgears/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Headgears/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Colour,Quantity")] Headgear headgear)
        {
            if (ModelState.IsValid)
            {
                _context.Add(headgear);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(headgear);
        }

        // GET: Headgears/Edit/5
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

        // POST: Headgears/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Colour,Quantity")] Headgear headgear)
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

        // GET: Headgears/Delete/5
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

        // POST: Headgears/Delete/5
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
