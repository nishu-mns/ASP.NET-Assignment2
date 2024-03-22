using System.ComponentModel.DataAnnotations;

namespace Assignment_2.DTOs
{
    public class DepartmentDto
    {
        
            public int Id { get; set; }
            [Required]
            [StringLength(50)]
            public string DepartmentName { get; set; }
        
    }
}
