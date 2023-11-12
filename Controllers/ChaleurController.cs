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
    public class ChaleurController : ControllerBase
    {
        private readonly GeocartContext _context;

        public ChaleurController(GeocartContext context)
        {
            _context = context;
        }

        // GET: api/Chaleur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Chaleur>>> GetChaleurs()
        {
            return await _context.Chaleurs.ToListAsync();
        }

        // GET: api/Chaleur/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Chaleur>> GetChaleur(int id)
        {
            var chaleur = await _context.Chaleurs.FindAsync(id);

            if (chaleur == null)
            {
                return NotFound();
            }

            return chaleur;
        }

        // PUT: api/Chaleur/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChaleur(int id, Chaleur chaleur)
        {
            if (id != chaleur.OgcFid)
            {
                return BadRequest();
            }

            _context.Entry(chaleur).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChaleurExists(id))
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

        // POST: api/Chaleur
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Chaleur>> PostChaleur(Chaleur chaleur)
        {
            _context.Chaleurs.Add(chaleur);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChaleur", new { id = chaleur.OgcFid }, chaleur);
        }

        // DELETE: api/Chaleur/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChaleur(int id)
        {
            var chaleur = await _context.Chaleurs.FindAsync(id);
            if (chaleur == null)
            {
                return NotFound();
            }

            _context.Chaleurs.Remove(chaleur);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChaleurExists(int id)
        {
            return _context.Chaleurs.Any(e => e.OgcFid == id);
        }
    }
}
