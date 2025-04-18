using EmployeeApp.Application.Interfaces;
using EmployeeApp.Data;
using EmployeeApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _repository;
        private readonly IApplicationDbContext _context;

        public EmployeeController(IEmployeeRepository repository, IApplicationDbContext context)
        {
            _repository = repository;
            _context = context;
        }

        [HttpGet("AllEmployees")]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repository.GetAllAsync());

        [HttpGet("EmployeeById")]
        public async Task<IActionResult> GetById(int id)
        {
            var emp = await _repository.GetByIdAsync(id);
            return emp == null ? NotFound() : Ok(emp);
        }

        [HttpPost("AddEmployee")]
        public async Task<IActionResult> Create([FromBody] EmployeeModel emp)
        {
            if (await _repository.IsDuplicateAsync(emp.Name, (DateTime)emp.DateOfBirth))
                return Conflict("Duplicate employee found.");

            await _repository.AddAsync(emp);
            return Ok(emp);
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> Update(int id, Employee emp)
        {
            if (id != emp.Id) return BadRequest();
            await _repository.UpdateAsync(emp);
            return Ok(emp);
        }

        [HttpDelete("DeleteEmpoyeeById")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return Ok("Successfully Employee Deleted");
        }

        [HttpPost("DeleteMultipleEmpoyees")]
        public async Task<IActionResult> DeleteMultiple([FromBody] int[] ids)
        {
            await _repository.DeleteMultipleAsync(ids);
            return NoContent();
        }
        [HttpGet("GeneratePdf")]
        public async Task<IActionResult> GeneratePdf()
        {
           var data =  await _repository.GeneratePdf();
            return Ok(data);
        }
        [HttpPost("Enter")]
        public async Task<IActionResult> enter(List<string> names)
        {
            foreach (var name in names)
            {
                State state = new State();
                state.StateName = name;
                _context.State.Add(state);
                _context.SaveChanges();

            }
                return Ok();
        }

    }
}
