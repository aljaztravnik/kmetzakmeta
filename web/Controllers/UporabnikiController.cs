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
    public class UporabnikiController : Controller
    {
        private readonly KmetContext _context;

        public UporabnikiController(KmetContext context)
        {
            _context = context;
        }

        // GET: Uporabniki
        public async Task<IActionResult> Index()
        {
            return View(await _context.Uporabniki.ToListAsync());
        }

        // GET: Uporabniki/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uporabnik = await _context.Uporabniki
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (uporabnik == null)
            {
                return NotFound();
            }

            return View(uporabnik);
        }

        // GET: Uporabniki/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uporabniki/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserID,Username,Password,Phone,Email,Address,Description")] Uporabnik uporabnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uporabnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uporabnik);
        }

        // GET: Uporabniki/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uporabnik = await _context.Uporabniki.FindAsync(id);
            if (uporabnik == null)
            {
                return NotFound();
            }
            return View(uporabnik);
        }

        // POST: Uporabniki/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserID,Username,Password,Phone,Email,Address,Description")] Uporabnik uporabnik)
        {
            if (id != uporabnik.UserID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uporabnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UporabnikExists(uporabnik.UserID))
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
            return View(uporabnik);
        }

        // GET: Uporabniki/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var uporabnik = await _context.Uporabniki
                .FirstOrDefaultAsync(m => m.UserID == id);
            if (uporabnik == null)
            {
                return NotFound();
            }

            return View(uporabnik);
        }

        // POST: Uporabniki/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var uporabnik = await _context.Uporabniki.FindAsync(id);
            if (uporabnik != null)
            {
                _context.Uporabniki.Remove(uporabnik);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UporabnikExists(int id)
        {
            return _context.Uporabniki.Any(e => e.UserID == id);
        }
    }
}
