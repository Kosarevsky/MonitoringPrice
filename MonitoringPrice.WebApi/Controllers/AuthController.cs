using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MonitoringPrice.WebApi.Entities.Context;

namespace MonitoringPrice.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetAuth(string userName, string password)
        {
            if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password))
            {
                var result = _context.Users
                    .Include(x => x.Role)
                    .FirstOrDefaultAsync(x => x.Email == userName && x.Password == password);
                if (result == null)
                {
                    Response.Headers.Append("token", "token");
                    return Ok(new Object());
                }
            }
            return NotFound();
        }
    }
}
