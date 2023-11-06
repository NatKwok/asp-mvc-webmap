using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using asp_mvc_webmap;

namespace asp_mvc_webmap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecheresseController : ControllerBase
    {
        private readonly GeocartContext _context;

        public SecheresseController(GeocartContext context)
        {
            _context = context;
        }

        // GET: api/Secheresse
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Secheress>>> GetSecheresses()
        {
            return await _context.Secheresses.ToListAsync();
        }

        // GET: api/Secheresse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Secheress>> GetSecheress(int id)
        {
            var secheress = await _context.Secheresses.FindAsync(id);

            if (secheress == null)
            {
                return NotFound();
            }

            return secheress;
        }

        // PUT: api/Secheresse/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSecheress(int id, Secheress secheress)
        {
            if (id != secheress.OgcFid)
            {
                return BadRequest();
            }

            _context.Entry(secheress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecheressExists(id))
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

        // POST: api/Secheresse
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Secheress>> PostSecheress(Secheress secheress)
        {
            _context.Secheresses.Add(secheress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSecheress", new { id = secheress.OgcFid }, secheress);
        }

        // DELETE: api/Secheresse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSecheress(int id)
        {
            var secheress = await _context.Secheresses.FindAsync(id);
            if (secheress == null)
            {
                return NotFound();
            }

            _context.Secheresses.Remove(secheress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SecheressExists(int id)
        {
            return _context.Secheresses.Any(e => e.OgcFid == id);
        }

    }
}
