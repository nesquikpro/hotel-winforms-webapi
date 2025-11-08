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
    public class RoomNumbersController : ControllerBase
    {
        private readonly db_a7e6f8_hotelContext _context;

        public RoomNumbersController(db_a7e6f8_hotelContext context)
        {
            _context = context;
        }

        // GET: api/RoomNumbers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomNumber>>> GetRoomNumbers()
        {
            return await _context.RoomNumbers.ToListAsync();
        }

        // GET: api/RoomNumbers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomNumber>> GetRoomNumber(int id)
        {
            var roomNumber = await _context.RoomNumbers.FindAsync(id);

            if (roomNumber == null)
            {
                return NotFound();
            }

            return roomNumber;
        }

        // PUT: api/RoomNumbers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomNumber(int id, RoomNumber roomNumber)
        {
            if (id != roomNumber.IdNumber)
            {
                return BadRequest();
            }

            _context.Entry(roomNumber).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !RoomNumberExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/RoomNumbers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoomNumber>> PostRoomNumber(RoomNumber roomNumber)
        {
            _context.RoomNumbers.Add(roomNumber);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoomNumber", new { id = roomNumber.IdNumber }, roomNumber);
        }

        // DELETE: api/RoomNumbers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomNumber(int id)
        {
            var roomNumber = await _context.RoomNumbers.FindAsync(id);
            if (roomNumber == null)
            {
                return NotFound();
            }

            _context.RoomNumbers.Remove(roomNumber);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoomNumberExists(int id)
        {
            return _context.RoomNumbers.Any(e => e.IdNumber == id);
        }
    }
}
