using Assignment_2.DTOs;

namespace Assignment_2.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDto> GetEmployeeByIdAsync(int id);
        Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync();
        Task AddEmployeeAsync(EmployeeDto employee);
        Task UpdateEmployeeAsync(int id, EmployeeDto employee);
        Task DeleteEmployeeAsync(int id);
    }
}
