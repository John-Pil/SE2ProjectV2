using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevisionController : ControllerBase
    {
        private readonly AnimalDbContext _context;

        public RevisionController(AnimalDbContext context)
        {
            _context = context;
        }

        // GET: api/Revision
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Revision>>> GetRevision()
        {
            return await _context.Revision.ToListAsync();
        }

        // GET: api/Revision/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Revision>> GetRevision(int id)
        {
            var revision = await _context.Revision.FindAsync(id);

            if (revision == null)
            {
                return NotFound();
            }

            return revision;
        }

        // PUT: api/Revision/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRevision(int id, Revision revision)
        {
            if (id != revision.Revisionid)
            {
                return BadRequest();
            }

            _context.Entry(revision).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RevisionExists(id))
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

        // POST: api/Revision
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Revision>> PostRevision(Revision revision)
        {
            _context.Revision.Add(revision);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRevision", new { id = revision.Revisionid }, revision);
        }

        // DELETE: api/Revision/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRevision(int id)
        {
            var revision = await _context.Revision.FindAsync(id);
            if (revision == null)
            {
                return NotFound();
            }

            _context.Revision.Remove(revision);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RevisionExists(int id)
        {
            return _context.Revision.Any(e => e.Revisionid == id);
        }
    }
}
