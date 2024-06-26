﻿using System.ComponentModel.DataAnnotations;

namespace Assignment_2.DTOs
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Range(21, 100, ErrorMessage = "Age must be between 21 and 100")]
        [Required(ErrorMessage = "Age is required.")]
        public int Age { get; set; }
        public int DepartmentId { get; set; }
        public decimal Salary { get; set; }
    }
}
