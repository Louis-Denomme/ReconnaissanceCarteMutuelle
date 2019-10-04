using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using projet.net.Models;
using System.Drawing;

namespace projet.net.Controllers
{
    [Route("api/Mutuelle")]
    [ApiController]
    public class MutuelleController : ControllerBase
    {
        private readonly projetContext _context;

        public MutuelleController(projetContext context)
        {
            _context = context;

            if (_context.Mutuelles.Count() == 0)
            {
                _context.Mutuelles.Add(new Mutuelle { Name = "Mutuelle1" });
                _context.Mutuelles.Add(new Mutuelle { Name = "Mutuelle2" });
                _context.Mutuelles.Add(new Mutuelle { Name = "Mutuelle3" });
                _context.Mutuelles.Add(new Mutuelle { Name = "Mutuelle4" });
                _context.Mutuelles.Add(new Mutuelle { Name = "Mutuelle5" });
                _context.SaveChanges();
            }
        }

        // GET: api/Mutuelle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mutuelle>>> GetMutuelles()
        {
            return await _context.Mutuelles.ToListAsync();
        }

        // GET: api/Mutuelle/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mutuelle>> GetMutuelle(long id)
        {
            var mutuelle = await _context.Mutuelles.FindAsync(id);

            if (mutuelle == null)
            {
                return NotFound();
            }

            return mutuelle;
        }

        // POST: api/Mutuelle
        [HttpPost]
        public async Task<ActionResult<Mutuelle>> PostMutuelle(Mutuelle mutuelle)
        {
            _context.Mutuelles.Add(mutuelle);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMutuelle), new { id = mutuelle.Id }, mutuelle);
        }

        // PUT: api/Mutuelle/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMutuelle(long id, Mutuelle mutuelle)
        {
            if (id != mutuelle.Id)
            {
                return BadRequest();
            }

            _context.Entry(mutuelle).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Mutuelle/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMutuelle(long id)
        {
            var mutuelle = await _context.Mutuelles.FindAsync(id);

            if (mutuelle == null)
            {
                return NotFound();
            }

            _context.Mutuelles.Remove(mutuelle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}