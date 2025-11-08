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
    public class DepartamentsController : ControllerBase
    {
        private readonly db_a7e6f8_hotelContext _context;

        public DepartamentsController(db_a7e6f8_hotelContext context)
        {
            _context = context;
        }

        // GET: api/Departaments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departament>>> GetDepartaments()
        {
            return await _context.Departaments.ToListAsync();
        }

        // GET: api/Departaments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departament>> GetDepartament(int id)
        {
            var departament = await _context.Departaments.FindAsync(id);

            if (departament == null)
            {
                return NotFound();
            }

            return departament;
        }

        // PUT: api/Departaments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartament(int id, Departament departament)
        {
            if (id != departament.IdDepartament)
            {
                return BadRequest();
            }

            _context.Entry(departament).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return !DepartamentExists(id) ? NotFound(id) : StatusCode(StatusCodes.Status500InternalServerError);
            }

            return NoContent();
        }

        // POST: api/Departaments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Departament>> PostDepartament(Departament departament)
        {
            _context.Departaments.Add(departament);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartament", new { id = departament.IdDepartament }, departament);
        }

        // DELETE: api/Departaments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartament(int id)
        {
            var departament = await _context.Departaments.FindAsync(id);
            if (departament == null)
            {
                return NotFound();
            }

            _context.Departaments.Remove(departament);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartamentExists(int id)
        {
            return _context.Departaments.Any(e => e.IdDepartament == id);
        }
    }
}
