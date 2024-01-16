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
    [Route("api/v1/OglasStroj")]
    [ApiController]
    public class OglasiStrojevApiController : ControllerBase
    {
        private readonly KmetContext _context;

        public OglasiStrojevApiController(KmetContext context)
        {
            _context = context;
        }

        // GET: api/OglasiStrojevApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OglasStroj>>> GetOglasiStrojev()
        {
            return await _context.OglasiStrojev.ToListAsync();
        }

        // GET: api/OglasiStrojevApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OglasStroj>> GetOglasStroj(int id)
        {
            var oglasStroj = await _context.OglasiStrojev.FindAsync(id);

            if (oglasStroj == null)
            {
                return NotFound();
            }

            return oglasStroj;
        }

        // PUT: api/OglasiStrojevApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOglasStroj(int id, OglasStroj oglasStroj)
        {
            if (id != oglasStroj.StrojOglasID)
            {
                return BadRequest();
            }

            _context.Entry(oglasStroj).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OglasStrojExists(id))
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

        // POST: api/OglasiStrojevApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OglasStroj>> PostOglasStroj(OglasStroj oglasStroj)
        {
            _context.OglasiStrojev.Add(oglasStroj);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOglasStroj", new { id = oglasStroj.StrojOglasID }, oglasStroj);
        }

        // DELETE: api/OglasiStrojevApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOglasStroj(int id)
        {
            var oglasStroj = await _context.OglasiStrojev.FindAsync(id);
            if (oglasStroj == null)
            {
                return NotFound();
            }

            _context.OglasiStrojev.Remove(oglasStroj);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OglasStrojExists(int id)
        {
            return _context.OglasiStrojev.Any(e => e.StrojOglasID == id);
        }
    }
}
