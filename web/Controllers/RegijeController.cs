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
    public class RegijeController : Controller
    {
        private readonly KmetContext _context;

        public RegijeController(KmetContext context)
        {
            _context = context;
        }

        // GET: Regije
        public async Task<IActionResult> Index()
        {
            return View(await _context.Regije.ToListAsync());
        }

        // GET: Regije/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regija = await _context.Regije
                .FirstOrDefaultAsync(m => m.RegionID == id);
            if (regija == null)
            {
                return NotFound();
            }

            return View(regija);
        }

        // GET: Regije/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Regije/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegionID,Name")] Regija regija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(regija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(regija);
        }

        // GET: Regije/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regija = await _context.Regije.FindAsync(id);
            if (regija == null)
            {
                return NotFound();
            }
            return View(regija);
        }

        // POST: Regije/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegionID,Name")] Regija regija)
        {
            if (id != regija.RegionID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(regija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegijaExists(regija.RegionID))
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
            return View(regija);
        }

        // GET: Regije/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var regija = await _context.Regije
                .FirstOrDefaultAsync(m => m.RegionID == id);
            if (regija == null)
            {
                return NotFound();
            }

            return View(regija);
        }

        // POST: Regije/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var regija = await _context.Regije.FindAsync(id);
            if (regija != null)
            {
                _context.Regije.Remove(regija);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegijaExists(int id)
        {
            return _context.Regije.Any(e => e.RegionID == id);
        }
    }
}
