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
    [Route("api/v1/Pasma")]
    [ApiController]
    [ApiKeyAuth]
    public class PasmeApiController : ControllerBase
    {
        private readonly KmetContext _context;

        public PasmeApiController(KmetContext context)
        {
            _context = context;
        }

        // GET: api/PasmeApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pasma>>> GetPasme()
        {
            return await _context.Pasme.ToListAsync();
        }

        // GET: api/PasmeApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pasma>> GetPasma(int id)
        {
            var pasma = await _context.Pasme.FindAsync(id);

            if (pasma == null)
            {
                return NotFound();
            }

            return pasma;
        }

        // PUT: api/PasmeApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPasma(int id, Pasma pasma)
        {
            if (id != pasma.BreedID)
            {
                return BadRequest();
            }

            _context.Entry(pasma).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PasmaExists(id))
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

        // POST: api/PasmeApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pasma>> PostPasma(Pasma pasma)
        {
            _context.Pasme.Add(pasma);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPasma", new { id = pasma.BreedID }, pasma);
        }

        // DELETE: api/PasmeApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePasma(int id)
        {
            var pasma = await _context.Pasme.FindAsync(id);
            if (pasma == null)
            {
                return NotFound();
            }

            _context.Pasme.Remove(pasma);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PasmaExists(int id)
        {
            return _context.Pasme.Any(e => e.BreedID == id);
        }
    }
}
