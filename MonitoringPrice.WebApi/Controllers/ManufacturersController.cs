using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringPrice.WebApi.Entities.Context;
using MonitoringPrice.WebApi.Entities.Models;

namespace MonitoringPrice.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManufacturersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ManufacturersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Manufacturers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manufacturer>>> GetManufacturer()
        {
            if (_context.Manufacturer == null)
            {
                return NotFound();
            }
            return await _context.Manufacturer.ToListAsync();
        }

        // GET: api/Manufacturers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Manufacturer>> GetManufacturer(int id)
        {
            if (_context.Manufacturer == null)
            {
                return NotFound();
            }
            var manufacturer = await _context.Manufacturer.FirstOrDefaultAsync(x => x.Id == id);

            if (manufacturer == null)
            {
                return NotFound();
            }

            return manufacturer;
        }


        // POST: api/Manufacturers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Manufacturer>> PostManufacturer(Manufacturer manufacturer)
        {
            if (_context.Manufacturer == null && manufacturer==null)
            {
                return Problem("Entity set 'AppDbContext.Manufacturer'  is null.");
            }
            _context.Manufacturer.Add(manufacturer);
            _context.Entry(manufacturer).State =  manufacturer.Id == default ? EntityState.Added : EntityState.Modified;

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManufacturer", new { id = manufacturer.Id }, manufacturer);
        }

        // DELETE: api/Manufacturers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManufacturer(int id)
        {
            if (_context.Manufacturer == null)
            {
                return NotFound();
            }
            var manufacturer = await _context.Manufacturer.FindAsync(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            _context.Manufacturer.Remove(manufacturer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
