using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalOrderItemController : ControllerBase
    {
        private readonly AnimalDbContext _context;

        public AnimalOrderItemController(AnimalDbContext context)
        {
            _context = context;
        }

        // GET: api/Animal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalOrderItem>>> GetAnimalsOrderItem()
        {
            return await _context.AnimalOrderItem.ToListAsync();
        }

        // GET: api/Animal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimalOrderItem>> GetAnimalOrderItem(int id)
        {
            var animal = await _context.AnimalOrderItem.FindAsync(id);

            if (animal == null)
            {
                return NotFound();
            }

            return animal;
        }

        // PUT: api/Animal/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimalOrderItem(int id, AnimalOrderItem animalOrderItem)
        {
            if (id != animalOrderItem.Orderid)
            {
                return BadRequest();
            }

            _context.Entry(animalOrderItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimalOrderItemExists(id))
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

        // POST: api/Animals
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimalOrderItem>> PostAnimalOrderItem(AnimalOrderItem animalOrderItem)
        {
            _context.AnimalOrderItem.Add(animalOrderItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimalOrderItem", new { id = animalOrderItem.Orderid }, animalOrderItem);
        }

        // DELETE: api/Animals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimalOrderItem(int id)
        {
            var animal = await _context.AnimalOrderItem.FindAsync(id);
            if (animal == null)
            {
                return NotFound();
            }

            _context.AnimalOrderItem.Remove(animal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimalOrderItemExists(int id)
        {
            return _context.AnimalOrderItem.Any(e => e.Orderid == id);
        }
    }
}
