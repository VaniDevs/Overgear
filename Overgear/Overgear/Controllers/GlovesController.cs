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
    public class GlovesController : Controller
    {
        private readonly OvergearContext _context;

        public GlovesController(OvergearContext context)
        {
            _context = context;
        }

        // GET: Gloves
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.DescSortParm = String.IsNullOrEmpty(sortOrder) ? "desc" : "";
            ViewBag.ColSortParm = String.IsNullOrEmpty(sortOrder) ? "col" : "";
            ViewBag.SizeSortParm = String.IsNullOrEmpty(sortOrder) ? "size" : "";
            ViewBag.QuanSortParm = String.IsNullOrEmpty(sortOrder) ? "quan" : "";

            var results = from x in _context.Gloves
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
        //    return View(await _context.Gloves.ToListAsync());
        //}

        // GET: Gloves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gloves = await _context.Gloves
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gloves == null)
            {
                return NotFound();
            }

            return View(gloves);
        }

        // GET: Gloves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gloves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Size,Colour,Quantity")] Gloves gloves)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gloves);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gloves);
        }

        // GET: Gloves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gloves = await _context.Gloves.FindAsync(id);
            if (gloves == null)
            {
                return NotFound();
            }
            return View(gloves);
        }

        // POST: Gloves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Size,Colour,Quantity")] Gloves gloves)
        {
            if (id != gloves.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gloves);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GlovesExists(gloves.ID))
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
            return View(gloves);
        }

        // GET: Gloves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gloves = await _context.Gloves
                .FirstOrDefaultAsync(m => m.ID == id);
            if (gloves == null)
            {
                return NotFound();
            }

            return View(gloves);
        }

        // POST: Gloves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gloves = await _context.Gloves.FindAsync(id);
            _context.Gloves.Remove(gloves);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GlovesExists(int id)
        {
            return _context.Gloves.Any(e => e.ID == id);
        }
    }
}
