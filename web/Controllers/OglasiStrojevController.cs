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
    public class OglasiStrojevController : Controller
    {
        private readonly KmetContext _context;

        public OglasiStrojevController(KmetContext context)
        {
            _context = context;
        }

        // GET: OglasiStrojev
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
            var oglasi = from s in _context.OglasiStrojev select s;
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
            return View(await PaginatedList<OglasStroj>.CreateAsync(oglasi.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: OglasiStrojev/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oglasStroj = await _context.OglasiStrojev
                .FirstOrDefaultAsync(m => m.StrojOglasID == id);
            if (oglasStroj == null)
            {
                return NotFound();
            }

            return View(oglasStroj);
        }

        // GET: OglasiStrojev/Create
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        // POST: OglasiStrojev/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("StrojOglasID,Title,Price,Age,WorkingHours,Power,Desc")] OglasStroj oglasStroj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(oglasStroj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(oglasStroj);
        }

        // GET: OglasiStrojev/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oglasStroj = await _context.OglasiStrojev.FindAsync(id);
            if (oglasStroj == null)
            {
                return NotFound();
            }
            return View(oglasStroj);
        }

        // POST: OglasiStrojev/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("StrojOglasID,Title,Price,Age,WorkingHours,Power,Desc")] OglasStroj oglasStroj)
        {
            if (id != oglasStroj.StrojOglasID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(oglasStroj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OglasStrojExists(oglasStroj.StrojOglasID))
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
            return View(oglasStroj);
        }

        // GET: OglasiStrojev/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oglasStroj = await _context.OglasiStrojev
                .FirstOrDefaultAsync(m => m.StrojOglasID == id);
            if (oglasStroj == null)
            {
                return NotFound();
            }

            return View(oglasStroj);
        }

        // POST: OglasiStrojev/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oglasStroj = await _context.OglasiStrojev.FindAsync(id);
            if (oglasStroj != null)
            {
                _context.OglasiStrojev.Remove(oglasStroj);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OglasStrojExists(int id)
        {
            return _context.OglasiStrojev.Any(e => e.StrojOglasID == id);
        }
    }
}
