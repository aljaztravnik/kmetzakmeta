using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    public class PasmeController : Controller
    {
        private readonly KmetContext _context;

        public PasmeController(KmetContext context)
        {
            _context = context;
        }

        // GET: Pasme
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pasme.ToListAsync());
        }

        // GET: Pasme/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasma = await _context.Pasme
                .FirstOrDefaultAsync(m => m.BreedID == id);
            if (pasma == null)
            {
                return NotFound();
            }

            return View(pasma);
        }

        // GET: Pasme/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pasme/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("BreedID,Breed")] Pasma pasma)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pasma);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pasma);
        }

        // GET: Pasme/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasma = await _context.Pasme.FindAsync(id);
            if (pasma == null)
            {
                return NotFound();
            }
            return View(pasma);
        }

        // POST: Pasme/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("BreedID,Breed")] Pasma pasma)
        {
            if (id != pasma.BreedID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pasma);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PasmaExists(pasma.BreedID))
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
            return View(pasma);
        }

        // GET: Pasme/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pasma = await _context.Pasme
                .FirstOrDefaultAsync(m => m.BreedID == id);
            if (pasma == null)
            {
                return NotFound();
            }

            return View(pasma);
        }

        // POST: Pasme/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pasma = await _context.Pasme.FindAsync(id);
            if (pasma != null)
            {
                _context.Pasme.Remove(pasma);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PasmaExists(int id)
        {
            return _context.Pasme.Any(e => e.BreedID == id);
        }
    }
}
