using Assignment_2.Data;
using Assignment_2.DTOs;
using Assignment_2.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using static Assignment_2.DTOs.DepartmentDto;

namespace Assignment_2.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public DepartmentService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<DepartmentDto> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            return department != null ?
                _mapper.Map<DepartmentDto>(department) 
                : null;
        }

        public async Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync()
        {
            var departments = await _context.Departments.ToListAsync();
            return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
        }

        public async Task AddDepartmentAsync(DepartmentDto departmentDto)
        {
            var department = _mapper.Map<Department>(departmentDto); 
            _context.Departments.Add(department);
            await _context.SaveChangesAsync(); 
        }

        public async Task UpdateDepartmentAsync(int id, DepartmentDto departmentDto)
        {
            var existingDepartment = await _context.Departments.FindAsync(id);
            if (existingDepartment == null)
                throw new NotFoundException("Department not found");

            _mapper.Map(departmentDto, existingDepartment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
                throw new NotFoundException("Department not found");

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }
    }
}
