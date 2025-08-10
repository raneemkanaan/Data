using App.Models;
using Database.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Database.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FloorsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FloorsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/floors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Floor>>> GetFloors()
        {
            return await _context.Floors
                //.Include(f => f.Venue)
                //.Include(f => f.Nodes)
                .ToListAsync();
        }

        // GET: api/floors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Floor>> GetFloor(int id)
        {
            var floor = await _context.Floors
                .Include(f => f.Venue)
                .Include(f => f.Nodes)
                .FirstOrDefaultAsync(f => f.Id == id);

            if (floor == null)
                return NotFound();

            return floor;
        }

        // POST: api/floors
        [HttpPost]
        public async Task<ActionResult<Floor>> PostFloor(Floor floor)
        {
            // تأكد من أن Venue موجود
            var venueExists = await _context.Venues.AnyAsync(v => v.Id == floor.VenueId);
            if (!venueExists)
                return BadRequest($"Venue with ID {floor.VenueId} does not exist.");

            _context.Floors.Add(floor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFloor), new { id = floor.Id }, floor);
        }

        // PUT: api/floors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFloor(int id, Floor floor)
        {
            if (id != floor.Id)
                return BadRequest();

            _context.Entry(floor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Floors.Any(e => e.Id == id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // DELETE: api/floors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFloor(int id)
        {
            var floor = await _context.Floors.FindAsync(id);
            if (floor == null)
                return NotFound();

            _context.Floors.Remove(floor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
