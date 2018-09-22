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
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gloves.ToListAsync());
        }

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
        public async Task<IActionResult> Create([Bind("ID,Description,Size,Quantity")] Gloves gloves)
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
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Size,Quantity")] Gloves gloves)
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
