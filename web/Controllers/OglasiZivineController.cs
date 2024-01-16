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
    public class OglasiZivineController : Controller
    {
        private readonly KmetContext _context;

        public OglasiZivineController(KmetContext context)
        {
            _context = context;
        }

        // GET: OglasiZivine
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int currentMaxPrice, int currentMinPrice, int? pageNumber, int maxPrice = 0, int minPrice = 0)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["PriceSortParam"] = String.IsNullOrEmpty(sortOrder) ? "price_desc" : "";
            if (searchString != null) pageNumber = 1;
            else searchString = currentFilter;

            if(maxPrice > 0 && minPrice > 0 && maxPrice > minPrice){
                pageNumber = 1;
                ViewData["CurrentMaxPrice"] = maxPrice;
                ViewData["CurrentMinPrice"] = minPrice;
            }else if(maxPrice > 0 && minPrice == 0){
                pageNumber = 1;
                ViewData["CurrentMaxPrice"] = maxPrice;
            }else if(minPrice > 0 && maxPrice == 0){
                pageNumber = 1;
                ViewData["CurrentMinPrice"] = minPrice;
            }

            ViewData["CurrentFilter"] = searchString;
            var oglasi = from s in _context.OglasiZivine select s;
            if (!String.IsNullOrEmpty(searchString))
                oglasi = oglasi.Where(s => s.Title.Contains(searchString));
            
            if(maxPrice > 0 && minPrice > 0 && maxPrice > minPrice)
                oglasi = oglasi.Where(s => s.Price <= maxPrice && s.Price >= minPrice);
            else if(maxPrice > 0 && minPrice == 0)
                oglasi = oglasi.Where(s => s.Price <= maxPrice);
            else if(minPrice > 0 && maxPrice == 0)
                oglasi = oglasi.Where(s => s.Price >= minPrice);
            
            switch(sortOrder){
                case "price_desc":
                    oglasi = oglasi.OrderByDescending(s => s.Price);
                    break;
                default:
                    oglasi = oglasi.OrderBy(s => s.Price);
                    break;
            }

            int pageSize = 10;
            return View(await PaginatedList<OglasZivina>.CreateAsync(oglasi.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: OglasiZivine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oglasZivina = await _context.OglasiZivine
                .FirstOrDefaultAsync(m => m.ZivinaOglasID == id);
            if (oglasZivina == null)
            {
                return NotFound();
            }

            return View(oglasZivina);
        }

        // GET: OglasiZivine/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: OglasiZivine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("ZivinaOglasID,Title,Price,Age,Weight,Sex,Desc,Offspring,Construction")] OglasZivina oglasZivina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oglasZivina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oglasZivina);
        }

        // GET: OglasiZivine/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oglasZivina = await _context.OglasiZivine.FindAsync(id);
            if (oglasZivina == null)
            {
                return NotFound();
            }
            return View(oglasZivina);
        }

        // POST: OglasiZivine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("ZivinaOglasID,Title,Price,Age,Weight,Sex,Desc,Offspring,Construction")] OglasZivina oglasZivina)
        {
            if (id != oglasZivina.ZivinaOglasID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oglasZivina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OglasZivinaExists(oglasZivina.ZivinaOglasID))
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
            return View(oglasZivina);
        }

        // GET: OglasiZivine/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oglasZivina = await _context.OglasiZivine
                .FirstOrDefaultAsync(m => m.ZivinaOglasID == id);
            if (oglasZivina == null)
            {
                return NotFound();
            }

            return View(oglasZivina);
        }

        // POST: OglasiZivine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oglasZivina = await _context.OglasiZivine.FindAsync(id);
            if (oglasZivina != null)
            {
                _context.OglasiZivine.Remove(oglasZivina);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OglasZivinaExists(int id)
        {
            return _context.OglasiZivine.Any(e => e.ZivinaOglasID == id);
        }
    }
}
