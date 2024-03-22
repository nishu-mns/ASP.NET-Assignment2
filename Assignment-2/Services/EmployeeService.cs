using Assignment_2.Data;
using Assignment_2.DTOs;
using Assignment_2.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2.Services
{
    public class EmployeeService: IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public EmployeeService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> GetEmployeeByIdAsync(int id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            return employee != null ? _mapper.Map<EmployeeDto>(employee) : null;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _dbContext.Employees.ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
        }

        public async Task AddEmployeeAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _dbContext.Employees.AddAsync(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateEmployeeAsync(int id, EmployeeDto employeeDto)
        {
            var existingEmployee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (existingEmployee == null)
                return; // No action if employee not found

            _mapper.Map(employeeDto, existingEmployee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _dbContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
            if (employee == null)
                return; // No action if employee not found

            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }
    }
}
