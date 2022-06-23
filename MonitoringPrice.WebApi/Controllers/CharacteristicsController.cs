using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringPrice.WebApi.Entities.Context;
using MonitoringPrice.WebApi.Entities.Models;

namespace MonitoringPrice.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacteristicsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CharacteristicsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Characteristics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Characteristic>>> GetCharacteristic()
        {
          if (_context.Characteristic == null)
          {
              return NotFound();
          }
            return await _context.Characteristic.ToListAsync();
        }

        // GET: api/Characteristics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Characteristic>> GetCharacteristic(int id)
        {
          if (_context.Characteristic == null)
          {
              return NotFound();
          }
            var characteristic = await _context.Characteristic.FindAsync(id);

            if (characteristic == null)
            {
                return NotFound();
            }

            return characteristic;
        }

        // PUT: api/Characteristics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacteristic(int id, Characteristic characteristic)
        {
            if (id != characteristic.Id)
            {
                return BadRequest();
            }

            _context.Entry(characteristic).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacteristicExists(id))
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

        // POST: api/Characteristics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Characteristic>> PostCharacteristic(Characteristic characteristic)
        {
          if (_context.Characteristic == null)
          {
              return Problem("Entity set 'AppDbContext.Characteristic'  is null.");
          }
            _context.Characteristic.Add(characteristic);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharacteristic", new { id = characteristic.Id }, characteristic);
        }

        // DELETE: api/Characteristics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacteristic(int id)
        {
            if (_context.Characteristic == null)
            {
                return NotFound();
            }
            var characteristic = await _context.Characteristic.FindAsync(id);
            if (characteristic == null)
            {
                return NotFound();
            }

            _context.Characteristic.Remove(characteristic);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CharacteristicExists(int id)
        {
            return (_context.Characteristic?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
