using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoNumberController : ControllerBase
    {
        private readonly AnimalDbContext _context;

        public AutoNumberController(AnimalDbContext context)
        {
            _context = context;
        }

        // GET: api/AutoNumber
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutoNumber>>> GetAutoNumber()
        {
            return await _context.AutoNumber.ToListAsync();
        }

        // GET: api/AutoNumber/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutoNumber>> GetAutoNumber(int id)
        {
            var autoNumber = await _context.AutoNumber.FindAsync(id);

            if (autoNumber == null)
            {
                return NotFound();
            }

            return autoNumber;
        }

        // PUT: api/AutoNumber/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutoNumber(string id, AutoNumber autoNumber)
        {
            if (id != autoNumber.Tablename)
            {
                return BadRequest();
            }

            _context.Entry(autoNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutoNumberExists(id))
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

        // POST: api/AutoNumber
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AutoNumber>> PostAutoNumber(AutoNumber autoNumber)
        {
            _context.AutoNumber.Add(autoNumber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutoNumber", new { id = autoNumber.Tablename }, autoNumber);
        }

        // DELETE: api/AutoNumber/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutoNumber(int id)
        {
            var autoNumber = await _context.AutoNumber.FindAsync(id);
            if (autoNumber == null)
            {
                return NotFound();
            }

            _context.AutoNumber.Remove(autoNumber);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutoNumberExists(string id)
        {
            return _context.AutoNumber.Any(e => e.Tablename == id);
        }
    }
}
