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
    [Route("api/v1/Regija")]
    [ApiController]
    [ApiKeyAuth]
    public class RegijeApiController : ControllerBase
    {
        private readonly KmetContext _context;

        public RegijeApiController(KmetContext context)
        {
            _context = context;
        }

        // GET: api/RegijeApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Regija>>> GetRegije()
        {
            return await _context.Regije.ToListAsync();
        }

        // GET: api/RegijeApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Regija>> GetRegija(int id)
        {
            var regija = await _context.Regije.FindAsync(id);

            if (regija == null)
            {
                return NotFound();
            }

            return regija;
        }

        // PUT: api/RegijeApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRegija(int id, Regija regija)
        {
            if (id != regija.RegionID)
            {
                return BadRequest();
            }

            _context.Entry(regija).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegijaExists(id))
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

        // POST: api/RegijeApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Regija>> PostRegija(Regija regija)
        {
            _context.Regije.Add(regija);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegija", new { id = regija.RegionID }, regija);
        }

        // DELETE: api/RegijeApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegija(int id)
        {
            var regija = await _context.Regije.FindAsync(id);
            if (regija == null)
            {
                return NotFound();
            }

            _context.Regije.Remove(regija);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegijaExists(int id)
        {
            return _context.Regije.Any(e => e.RegionID == id);
        }
    }
}
