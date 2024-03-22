using Assignment_2.DTOs;
using Assignment_2.Models;
using AutoMapper;

namespace Assignment_2.Mapper
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Department, DepartmentDto>().ReverseMap();
        }
    }
}
