using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using web.Filters;

namespace web.Controllers_Api
{
    [Route("api/v1/Znamka")]
    [ApiController]
    [ApiKeyAuth]
    public class ZnamkeApiController : ControllerBase
    {
        private readonly KmetContext _context;

        public ZnamkeApiController(KmetContext context)
        {
            _context = context;
        }

        // GET: api/ZnamkeApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Znamka>>> GetZnamke()
        {
            return await _context.Znamke.ToListAsync();
        }

        // GET: api/ZnamkeApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Znamka>> GetZnamka(int id)
        {
            var znamka = await _context.Znamke.FindAsync(id);

            if (znamka == null)
            {
                return NotFound();
            }

            return znamka;
        }

        // PUT: api/ZnamkeApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutZnamka(int id, Znamka znamka)
        {
            if (id != znamka.BrandID)
            {
                return BadRequest();
            }

            _context.Entry(znamka).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZnamkaExists(id))
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

        // POST: api/ZnamkeApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Znamka>> PostZnamka(Znamka znamka)
        {
            _context.Znamke.Add(znamka);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetZnamka", new { id = znamka.BrandID }, znamka);
        }

        // DELETE: api/ZnamkeApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteZnamka(int id)
        {
            var znamka = await _context.Znamke.FindAsync(id);
            if (znamka == null)
            {
                return NotFound();
            }

            _context.Znamke.Remove(znamka);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ZnamkaExists(int id)
        {
            return _context.Znamke.Any(e => e.BrandID == id);
        }
    }
}
