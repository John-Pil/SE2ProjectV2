using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreferencesController : ControllerBase
    {
        private readonly AnimalDbContext _context;

        public PreferencesController(AnimalDbContext context)
        {
            _context = context;
        }

        // GET: api/Preference
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Preference>>> GetPreference()
        {
            return await _context.Preference.ToListAsync();
        }

        // GET: api/Preference/5
        [HttpGet("{Keyid}")]
        public async Task<ActionResult<Preference>> GetPreference(string keyId)
        {
            var preference = await _context.Preference.FindAsync(keyId);

            if (preference == null)
            { 
            
                return NotFound();
            }
        return preference;
            
        }

        // PUT: api/Preference/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{Keyid}")]
        public async Task<IActionResult> PutPreference(string keyId, Preference preference)
        {
            if (keyId != preference.Keyid)
            {
                return BadRequest();
            }

            _context.Entry(preference).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PreferenceExists(keyId))
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

        // POST: api/Preference
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Animal>> PostPreference(Preference preference)
        {
            _context.Preference.Add(preference);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPreference", new { id = preference.Keyid }, preference);
        }

        // DELETE: api/Preference/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePreference(string keyId)
        {
            var preference = await _context.Preference.FindAsync(keyId);
            if (preference == null)
            {
                return NotFound();
            }

            _context.Preference.Remove(preference);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PreferenceExists(string keyId)
        {
            return _context.Preference.Any(e => e.Keyid == keyId);
        }
    }
}
