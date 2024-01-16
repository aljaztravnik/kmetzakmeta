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
    [Route("api/v1/OglasZivina")]
    [ApiController]
    public class OglasiZivineApiController : ControllerBase
    {
        private readonly KmetContext _context;

        public OglasiZivineApiController(KmetContext context)
        {
            _context = context;
        }

        // GET: api/OglasiZivineApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OglasZivina>>> GetOglasiZivine()
        {
            return await _context.OglasiZivine.ToListAsync();
        }

        // GET: api/OglasiZivineApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OglasZivina>> GetOglasZivina(int id)
        {
            var oglasZivina = await _context.OglasiZivine.FindAsync(id);

            if (oglasZivina == null)
            {
                return NotFound();
            }

            return oglasZivina;
        }

        // PUT: api/OglasiZivineApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOglasZivina(int id, OglasZivina oglasZivina)
        {
            if (id != oglasZivina.ZivinaOglasID)
            {
                return BadRequest();
            }

            _context.Entry(oglasZivina).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OglasZivinaExists(id))
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

        // POST: api/OglasiZivineApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OglasZivina>> PostOglasZivina(OglasZivina oglasZivina)
        {
            _context.OglasiZivine.Add(oglasZivina);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOglasZivina", new { id = oglasZivina.ZivinaOglasID }, oglasZivina);
        }

        // DELETE: api/OglasiZivineApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOglasZivina(int id)
        {
            var oglasZivina = await _context.OglasiZivine.FindAsync(id);
            if (oglasZivina == null)
            {
                return NotFound();
            }

            _context.OglasiZivine.Remove(oglasZivina);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OglasZivinaExists(int id)
        {
            return _context.OglasiZivine.Any(e => e.ZivinaOglasID == id);
        }
    }
}
