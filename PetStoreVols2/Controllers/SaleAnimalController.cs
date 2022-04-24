using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleAnimalController : ControllerBase
    {
        private readonly AnimalDbContext _context;

        public SaleAnimalController(AnimalDbContext context)
        {
            _context = context;
        }

        // GET: api/SaleAnimal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleAnimal>>> GetSaleAnimals()
        {
            return await _context.SaleAnimal.ToListAsync();
        }

        // GET: api/SaleAnimal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleAnimal>> GetSaleAnimal(int id)
        {
            var saleAnimal = await _context.SaleAnimal.FindAsync(id);

            if (saleAnimal == null)
            {
                return NotFound();
            }

            return saleAnimal;
        }

        // PUT: api/SaleAnimal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleAnimal(int id, SaleAnimal saleAnimal)
        {
            if (id != saleAnimal.Saleid)
            {
                return BadRequest();
            }

            _context.Entry(saleAnimal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleAnimalExists(id))
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

        // POST: api/SaleAnimals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SaleAnimal>> PostSaleAnimal(SaleAnimal saleAnimal)
        {
            _context.SaleAnimal.Add(saleAnimal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaleAnimal", new { id = saleAnimal.Saleid }, saleAnimal);
        }

        // DELETE: api/SaleAnimals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleAnimal(int id)
        {
            var saleAnimal = await _context.SaleAnimal.FindAsync(id);
            if (saleAnimal == null)
            {
                return NotFound();
            }

            _context.SaleAnimal.Remove(saleAnimal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleAnimalExists(int id)
        {
            return _context.SaleAnimal.Any(e => e.Saleid == id);
        }
    }
}
