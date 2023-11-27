using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    public class ZnamkeController : Controller
    {
        private readonly KmetContext _context;

        public ZnamkeController(KmetContext context)
        {
            _context = context;
        }

        // GET: Znamke
        public async Task<IActionResult> Index()
        {
            return View(await _context.Znamke.ToListAsync());
        }

        // GET: Znamke/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var znamka = await _context.Znamke
                .FirstOrDefaultAsync(m => m.BrandID == id);
            if (znamka == null)
            {
                return NotFound();
            }

            return View(znamka);
        }

        // GET: Znamke/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Znamke/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandID,Name")] Znamka znamka)
        {
            if (ModelState.IsValid)
            {
                _context.Add(znamka);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(znamka);
        }

        // GET: Znamke/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var znamka = await _context.Znamke.FindAsync(id);
            if (znamka == null)
            {
                return NotFound();
            }
            return View(znamka);
        }

        // POST: Znamke/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrandID,Name")] Znamka znamka)
        {
            if (id != znamka.BrandID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(znamka);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZnamkaExists(znamka.BrandID))
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
            return View(znamka);
        }

        // GET: Znamke/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var znamka = await _context.Znamke
                .FirstOrDefaultAsync(m => m.BrandID == id);
            if (znamka == null)
            {
                return NotFound();
            }

            return View(znamka);
        }

        // POST: Znamke/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var znamka = await _context.Znamke.FindAsync(id);
            if (znamka != null)
            {
                _context.Znamke.Remove(znamka);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZnamkaExists(int id)
        {
            return _context.Znamke.Any(e => e.BrandID == id);
        }
    }
}
