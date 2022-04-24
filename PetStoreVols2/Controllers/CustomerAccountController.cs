using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetStoreRestAPI3.Models;

namespace PetStoreRestAPI3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAccountController : ControllerBase
    {
        private readonly AnimalDbContext _context;

        public CustomerAccountController(AnimalDbContext context)
        {
            _context = context;
        }

        // GET: api/CustomerAccount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerAccount>>> GetCustomerAccount()
        {
            return await _context.CustomerAccount.ToListAsync();
        }

        // GET: api/CustomerAccount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerAccount>> GetCustomerAccount(int id)
        {
            var customerAccount = await _context.CustomerAccount.FindAsync(id);

            if (customerAccount == null)
            {
                return NotFound();
            }

            return customerAccount;
        }

        // PUT: api/CustomerAccount/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerAccount(int id, CustomerAccount customerAccount)
        {
            if (id != customerAccount.Accountid)
            {
                return BadRequest();
            }

            _context.Entry(customerAccount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerAccountExists(id))
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

        // POST: api/CustomerAccount
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerAccount>> PostCustomerAccount(CustomerAccount customerAccount)
        {
            _context.CustomerAccount.Add(customerAccount);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerAccount", new { id = customerAccount.Accountid }, customerAccount);
        }

        // DELETE: api/CustomerAccount/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerAccount(int id)
        {
            var customerAccount = await _context.CustomerAccount.FindAsync(id);
            if (customerAccount == null)
            {
                return NotFound();
            }

            _context.CustomerAccount.Remove(customerAccount);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerAccountExists(int id)
        {
            return _context.CustomerAccount.Any(e => e.Accountid == id);
        }
    }
}
