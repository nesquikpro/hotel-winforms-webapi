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
    public class OrderingRoomsController : ControllerBase
    {
        private readonly db_a7e6f8_hotelContext _context;

        public OrderingRoomsController(db_a7e6f8_hotelContext context)
        {
            _context = context;
        }

        // GET: api/OrderingRooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderingRoom>>> GetOrderingRooms()
        {
            return await _context.OrderingRooms.ToListAsync();
        }

        // GET: api/OrderingRooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderingRoom>> GetOrderingRoom(int id)
        {
            var orderingRoom = await _context.OrderingRooms.FindAsync(id);

            if (orderingRoom == null)
            {
                return NotFound();
            }

            return orderingRoom;
        }

        // PUT: api/OrderingRooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderingRoom(int id, OrderingRoom orderingRoom)
        {
            if (id != orderingRoom.IdOrderingRoom)
            {
                return BadRequest();
            }

            _context.Entry(orderingRoom).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !OrderingRoomExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/OrderingRooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderingRoom>> PostOrderingRoom(OrderingRoom orderingRoom)
        {
            _context.OrderingRooms.Add(orderingRoom);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderingRoom", new { id = orderingRoom.IdOrderingRoom }, orderingRoom);
        }

        // DELETE: api/OrderingRooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderingRoom(int id)
        {
            var orderingRoom = await _context.OrderingRooms.FindAsync(id);
            if (orderingRoom == null)
            {
                return NotFound();
            }

            _context.OrderingRooms.Remove(orderingRoom);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderingRoomExists(int id)
        {
            return _context.OrderingRooms.Any(e => e.IdOrderingRoom == id);
        }
    }
}
