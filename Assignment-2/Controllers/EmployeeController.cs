using Assignment_2.DTOs;
using Assignment_2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetAllEmployees()
        {  // Retrieve all employees from the service
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] EmployeeDto employeeDto)

        {// Return bad request if model state is invalid
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _employeeService.AddEmployeeAsync(employeeDto);
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding the employee: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] EmployeeDto employeeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                await _employeeService.UpdateEmployeeAsync(id, employeeDto);
                return Ok(employeeDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating the employee: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                await _employeeService.DeleteEmployeeAsync(id);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the employee: {ex.Message}");
            }
        }
        
    }
}
