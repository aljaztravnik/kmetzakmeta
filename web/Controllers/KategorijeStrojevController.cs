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
    public class KategorijeStrojevController : Controller
    {
        private readonly KmetContext _context;

        public KategorijeStrojevController(KmetContext context)
        {
            _context = context;
        }

        // GET: KategorijeStrojev
        public async Task<IActionResult> Index()
        {
            return View(await _context.KategorijeStrojev.ToListAsync());
        }

        // GET: KategorijeStrojev/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorijaStroja = await _context.KategorijeStrojev
                .FirstOrDefaultAsync(m => m.MachineTypeID == id);
            if (kategorijaStroja == null)
            {
                return NotFound();
            }

            return View(kategorijaStroja);
        }

        // GET: KategorijeStrojev/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KategorijeStrojev/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MachineTypeID,Name")] KategorijaStroja kategorijaStroja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategorijaStroja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategorijaStroja);
        }

        // GET: KategorijeStrojev/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorijaStroja = await _context.KategorijeStrojev.FindAsync(id);
            if (kategorijaStroja == null)
            {
                return NotFound();
            }
            return View(kategorijaStroja);
        }

        // POST: KategorijeStrojev/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MachineTypeID,Name")] KategorijaStroja kategorijaStroja)
        {
            if (id != kategorijaStroja.MachineTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategorijaStroja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategorijaStrojaExists(kategorijaStroja.MachineTypeID))
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
            return View(kategorijaStroja);
        }

        // GET: KategorijeStrojev/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategorijaStroja = await _context.KategorijeStrojev
                .FirstOrDefaultAsync(m => m.MachineTypeID == id);
            if (kategorijaStroja == null)
            {
                return NotFound();
            }

            return View(kategorijaStroja);
        }

        // POST: KategorijeStrojev/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kategorijaStroja = await _context.KategorijeStrojev.FindAsync(id);
            if (kategorijaStroja != null)
            {
                _context.KategorijeStrojev.Remove(kategorijaStroja);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategorijaStrojaExists(int id)
        {
            return _context.KategorijeStrojev.Any(e => e.MachineTypeID == id);
        }
    }
}
