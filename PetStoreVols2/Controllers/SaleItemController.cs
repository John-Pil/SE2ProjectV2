using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleItemController : ControllerBase
    {
        private readonly AnimalDbContext _context;

        public SaleItemController(AnimalDbContext context)
        {
            _context = context;
        }

        // GET: api/SaleItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleItem>>> GetSaleItem()
        {
            return await _context.SaleItem.ToListAsync();
        }

        // GET: api/SaleItem/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleItem>> GetSaleitem(int id)
        {
            var saleItem = await _context.SaleItem.FindAsync(id);

            if (saleItem == null)
            {
                return NotFound();
            }

            return saleItem;
        }

        // PUT: api/SaleItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleItem(int id, SaleItem saleItem)
        {
            if (id != saleItem.Saleid)
            {
                return BadRequest();
            }

            _context.Entry(saleItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleItemExists(id))
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

        // POST: api/SaleItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SaleItem>> PostAnimal(SaleItem saleItem)
        {
            _context.SaleItem.Add(saleItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaleItem", new { id = saleItem.Saleid }, saleItem);
        }

        // DELETE: api/SaleItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleItem(int id)
        {
            var saleItem = await _context.SaleItem.FindAsync(id);
            if (saleItem == null)
            {
                return NotFound();
            }

            _context.SaleItem.Remove(saleItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleItemExists(int id)
        {
            return _context.SaleItem.Any(e => e.Saleid == id);
        }
    }
}
