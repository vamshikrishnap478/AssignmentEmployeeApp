using EmployeeApp.Application.Interfaces;
using EmployeeApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateController : Controller
    {
        private readonly IApplicationDbContext _context;

        public StateController(IApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("AllStatesList")]
        public async Task<IActionResult> GetStates()
        {
            var states = await _context.State.ToListAsync();
            return Ok(states);
        }
    }
}
