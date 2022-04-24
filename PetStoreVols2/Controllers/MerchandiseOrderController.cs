using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MerchandiseOrderController : ControllerBase
    {
        private readonly AnimalDbContext _context;

        public MerchandiseOrderController(AnimalDbContext context)
        {
            _context = context;
        }

        // GET: api/MerchandiseOrder
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MerchandiseOrder>>> GetMerchandiseOrder()
        {
            return await _context.MerchandiseOrder.ToListAsync();
        }

        // GET: api/MerchandiseOrder/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MerchandiseOrder>> GetMerchandiseOrder(int id)
        {
            var merchandiseOrder = await _context.MerchandiseOrder.FindAsync(id);

            if (merchandiseOrder == null)
            {
                return NotFound();
            }

            return merchandiseOrder;
        }

        // PUT: api/MerchandiseOrder/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMerchandiseOrder(int id, MerchandiseOrder merchandiseOrder)
        {
            if (id != merchandiseOrder.Ponumber)
            {
                return BadRequest();
            }

            _context.Entry(merchandiseOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MerchandiseOrderExists(id))
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

        // POST: api/MerchandiseOrder
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MerchandiseOrder>> PostMerchandiseOrder(MerchandiseOrder merchandiseOrder)
        {
            _context.MerchandiseOrder.Add(merchandiseOrder);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMerchandiseOrder", new { id = merchandiseOrder.Ponumber }, merchandiseOrder);
        }

        // DELETE: api/MerchandiseOrder/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMerchandiseOrder(int id)
        {
            var merchandiseOrder = await _context.MerchandiseOrder.FindAsync(id);
            if (merchandiseOrder == null)
            {
                return NotFound();
            }

            _context.MerchandiseOrder.Remove(merchandiseOrder);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MerchandiseOrderExists(int id)
        {
            return _context.MerchandiseOrder.Any(e => e.Ponumber == id);
        }
    }
}
