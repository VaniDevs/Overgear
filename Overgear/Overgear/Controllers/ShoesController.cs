﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Overgear.Models;

namespace Overgear.Controllers
{
    public class ShoesController : Controller
    {
        private readonly OvergearContext _context;

        public ShoesController(OvergearContext context)
        {
            _context = context;
        }

        // GET: Shoes
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewBag.DescSortParm = String.IsNullOrEmpty(sortOrder) ? "desc" : "";
            ViewBag.ColSortParm = String.IsNullOrEmpty(sortOrder) ? "col" : "";
            ViewBag.SizeSortParm = sortOrder == "Size" ? "size" : "size_desc";
            ViewBag.QuanSortParm = String.IsNullOrEmpty(sortOrder) ? "quan" : "";

            var results = from x in _context.Shoe
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
                case "size_desc":
                    results = results.OrderByDescending(s => s.Size);
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
        //    return View(await _context.Shoe.ToListAsync());
        //}

        // GET: Shoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // GET: Shoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Shoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Description,Size,Colour,Quantity")] Shoe shoe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(shoe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(shoe);
        }

        // GET: Shoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe.FindAsync(id);
            if (shoe == null)
            {
                return NotFound();
            }
            return View(shoe);
        }

        // POST: Shoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Description,Size,Colour,Quantity")] Shoe shoe)
        {
            if (id != shoe.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(shoe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ShoeExists(shoe.ID))
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
            return View(shoe);
        }

        // GET: Shoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var shoe = await _context.Shoe
                .FirstOrDefaultAsync(m => m.ID == id);
            if (shoe == null)
            {
                return NotFound();
            }

            return View(shoe);
        }

        // POST: Shoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var shoe = await _context.Shoe.FindAsync(id);
            _context.Shoe.Remove(shoe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ShoeExists(int id)
        {
            return _context.Shoe.Any(e => e.ID == id);
        }
    }
}
