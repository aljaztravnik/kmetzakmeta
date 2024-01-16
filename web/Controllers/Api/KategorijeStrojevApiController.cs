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
    [Route("api/v1/KategorijaStroja")]
    [ApiController]
    public class KategorijeStrojevApiController : ControllerBase
    {
        private readonly KmetContext _context;

        public KategorijeStrojevApiController(KmetContext context)
        {
            _context = context;
        }

        // GET: api/KategorijeStrojevApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KategorijaStroja>>> GetKategorijeStrojev()
        {
            return await _context.KategorijeStrojev.ToListAsync();
        }

        // GET: api/KategorijeStrojevApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KategorijaStroja>> GetKategorijaStroja(int id)
        {
            var kategorijaStroja = await _context.KategorijeStrojev.FindAsync(id);

            if (kategorijaStroja == null)
            {
                return NotFound();
            }

            return kategorijaStroja;
        }

        // PUT: api/KategorijeStrojevApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategorijaStroja(int id, KategorijaStroja kategorijaStroja)
        {
            if (id != kategorijaStroja.MachineTypeID)
            {
                return BadRequest();
            }

            _context.Entry(kategorijaStroja).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategorijaStrojaExists(id))
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

        // POST: api/KategorijeStrojevApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KategorijaStroja>> PostKategorijaStroja(KategorijaStroja kategorijaStroja)
        {
            _context.KategorijeStrojev.Add(kategorijaStroja);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKategorijaStroja", new { id = kategorijaStroja.MachineTypeID }, kategorijaStroja);
        }

        // DELETE: api/KategorijeStrojevApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKategorijaStroja(int id)
        {
            var kategorijaStroja = await _context.KategorijeStrojev.FindAsync(id);
            if (kategorijaStroja == null)
            {
                return NotFound();
            }

            _context.KategorijeStrojev.Remove(kategorijaStroja);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KategorijaStrojaExists(int id)
        {
            return _context.KategorijeStrojev.Any(e => e.MachineTypeID == id);
        }
    }
}
