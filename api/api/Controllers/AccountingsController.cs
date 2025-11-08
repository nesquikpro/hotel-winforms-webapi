using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountingsController : ControllerBase
    {
        private readonly db_a7e6f8_hotelContext _context;

        public AccountingsController(db_a7e6f8_hotelContext context)
        {
            _context = context;
        }

        // GET: api/Accountings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Accounting>>> GetAccountings()
        {
            return await _context.Accountings.ToListAsync();
        }

        // GET: api/Accountings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Accounting>> GetAccounting(int id)
        {
            var accounting = await _context.Accountings.FindAsync(id);

            if (accounting == null)
            {
                return NotFound();
            }

            return accounting;
        }

        // PUT: api/Accountings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccounting(int id, Accounting accounting)
        {
            if (id != accounting.IdAccounting)
            {
                return BadRequest();
            }

            _context.Entry(accounting).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !AccountingExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/Accountings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Accounting>> PostAccounting(Accounting accounting)
        {
            _context.Accountings.Add(accounting);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccounting", new { id = accounting.IdAccounting }, accounting);
        }

        // DELETE: api/Accountings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccounting(int id)
        {
            var accounting = await _context.Accountings.FindAsync(id);
            if (accounting == null)
            {
                return NotFound();
            }

            _context.Accountings.Remove(accounting);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountingExists(int id)
        {
            return _context.Accountings.Any(e => e.IdAccounting == id);
        }
    }
}
