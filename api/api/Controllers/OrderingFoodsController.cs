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
    public class OrderingFoodsController : ControllerBase
    {
        private readonly db_a7e6f8_hotelContext _context;

        public OrderingFoodsController(db_a7e6f8_hotelContext context)
        {
            _context = context;
        }

        // GET: api/OrderingFoods
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderingFood>>> GetOrderingFoods()
        {
            return await _context.OrderingFoods.ToListAsync();
        }

        // GET: api/OrderingFoods/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderingFood>> GetOrderingFood(int id)
        {
            var orderingFood = await _context.OrderingFoods.FindAsync(id);

            if (orderingFood == null)
            {
                return NotFound();
            }

            return orderingFood;
        }

        // PUT: api/OrderingFoods/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderingFood(int id, OrderingFood orderingFood)
        {
            if (id != orderingFood.IdOrderingFood)
            {
                return BadRequest();
            }

            _context.Entry(orderingFood).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !OrderingFoodExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/OrderingFoods
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<OrderingFood>> PostOrderingFood(OrderingFood orderingFood)
        {
            _context.OrderingFoods.Add(orderingFood);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrderingFood", new { id = orderingFood.IdOrderingFood }, orderingFood);
        }

        // DELETE: api/OrderingFoods/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderingFood(int id)
        {
            var orderingFood = await _context.OrderingFoods.FindAsync(id);
            if (orderingFood == null)
            {
                return NotFound();
            }

            _context.OrderingFoods.Remove(orderingFood);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool OrderingFoodExists(int id)
        {
            return _context.OrderingFoods.Any(e => e.IdOrderingFood == id);
        }
    }
}
