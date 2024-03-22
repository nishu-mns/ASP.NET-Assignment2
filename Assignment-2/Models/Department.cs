using System.ComponentModel.DataAnnotations;

namespace Assignment_2.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string DepartmentName { get; set; }
    }
}
