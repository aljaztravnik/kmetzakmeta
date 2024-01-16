using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers_Api
{
    [Route("api/v1/Uporabnik")]
    [ApiController]
    public class UporabnikiApiController : ControllerBase
    {
        private readonly KmetContext _context;

        public UporabnikiApiController(KmetContext context)
        {
            _context = context;
        }

        // GET: api/UporabnikiApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uporabnik>>> GetUporabniki()
        {
            return await _context.Uporabniki.ToListAsync();
        }

        // GET: api/UporabnikiApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Uporabnik>> GetUporabnik(int id)
        {
            var uporabnik = await _context.Uporabniki.FindAsync(id);

            if (uporabnik == null)
            {
                return NotFound();
            }

            return uporabnik;
        }

        // PUT: api/UporabnikiApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUporabnik(int id, Uporabnik uporabnik)
        {
            if (id != uporabnik.UserID)
            {
                return BadRequest();
            }

            _context.Entry(uporabnik).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UporabnikExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UporabnikiApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Uporabnik>> PostUporabnik(Uporabnik uporabnik)
        {
            _context.Uporabniki.Add(uporabnik);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUporabnik", new { id = uporabnik.UserID }, uporabnik);
        }

        // DELETE: api/UporabnikiApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUporabnik(int id)
        {
            var uporabnik = await _context.Uporabniki.FindAsync(id);
            if (uporabnik == null)
            {
                return NotFound();
            }

            _context.Uporabniki.Remove(uporabnik);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UporabnikExists(int id)
        {
            return _context.Uporabniki.Any(e => e.UserID == id);
        }
    }
}
