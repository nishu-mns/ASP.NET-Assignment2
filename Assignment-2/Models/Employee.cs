using System.ComponentModel.DataAnnotations;

namespace Assignment_2.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Range(21, 100)]
        public int Age { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        [Required]
        public decimal Salary { get; set; }
    }
}
