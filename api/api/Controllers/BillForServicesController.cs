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
    public class BillForServicesController : ControllerBase
    {
        private readonly db_a7e6f8_hotelContext _context;

        public BillForServicesController(db_a7e6f8_hotelContext context)
        {
            _context = context;
        }

        // GET: api/BillForServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BillForService>>> GetBillForServices()
        {
            return await _context.BillForServices.ToListAsync();
        }

        // GET: api/BillForServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BillForService>> GetBillForService(int id)
        {
            var billForService = await _context.BillForServices.FindAsync(id);

            if (billForService == null)
            {
                return NotFound();
            }

            return billForService;
        }

        // PUT: api/BillForServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBillForService(int id, BillForService billForService)
        {
            if (id != billForService.IdBillForServices)
            {
                return BadRequest();
            }

            _context.Entry(billForService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !BillForServiceExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/BillForServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BillForService>> PostBillForService(BillForService billForService)
        {
            _context.BillForServices.Add(billForService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBillForService", new { id = billForService.IdBillForServices }, billForService);
        }

        // DELETE: api/BillForServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBillForService(int id)
        {
            var billForService = await _context.BillForServices.FindAsync(id);
            if (billForService == null)
            {
                return NotFound();
            }

            _context.BillForServices.Remove(billForService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BillForServiceExists(int id)
        {
            return _context.BillForServices.Any(e => e.IdBillForServices == id);
        }
    }
}
