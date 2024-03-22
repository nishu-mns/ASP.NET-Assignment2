using Assignment_2.DTOs;

namespace Assignment_2.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentDto> GetDepartmentByIdAsync(int id);
        Task<IEnumerable<DepartmentDto>> GetAllDepartmentsAsync();
        Task AddDepartmentAsync(DepartmentDto department);
        Task UpdateDepartmentAsync(int id, DepartmentDto department);
        Task DeleteDepartmentAsync(int id);
    }
}
