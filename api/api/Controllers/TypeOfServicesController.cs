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
    public class TypeOfServicesController : ControllerBase
    {
        private readonly db_a7e6f8_hotelContext _context;

        public TypeOfServicesController(db_a7e6f8_hotelContext context)
        {
            _context = context;
        }

        // GET: api/TypeOfServices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TypeOfService>>> GetTypeOfServices()
        {
            return await _context.TypeOfServices.ToListAsync();
        }

        // GET: api/TypeOfServices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TypeOfService>> GetTypeOfService(int id)
        {
            var typeOfService = await _context.TypeOfServices.FindAsync(id);

            if (typeOfService == null)
            {
                return NotFound();
            }

            return typeOfService;
        }

        // PUT: api/TypeOfServices/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTypeOfService(int id, TypeOfService typeOfService)
        {
            if (id != typeOfService.IdTypeOfServices)
            {
                return BadRequest();
            }

            _context.Entry(typeOfService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !TypeOfServiceExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/TypeOfServices
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TypeOfService>> PostTypeOfService(TypeOfService typeOfService)
        {
            _context.TypeOfServices.Add(typeOfService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTypeOfService", new { id = typeOfService.IdTypeOfServices }, typeOfService);
        }

        // DELETE: api/TypeOfServices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTypeOfService(int id)
        {
            var typeOfService = await _context.TypeOfServices.FindAsync(id);
            if (typeOfService == null)
            {
                return NotFound();
            }

            _context.TypeOfServices.Remove(typeOfService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TypeOfServiceExists(int id)
        {
            return _context.TypeOfServices.Any(e => e.IdTypeOfServices == id);
        }
    }
}
