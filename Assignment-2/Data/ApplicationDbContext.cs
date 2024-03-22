using Assignment_2.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)               // Each employee belongs to one department
                .WithMany()                             // A department can have multiple employees
                .HasForeignKey(e => e.DepartmentId)     // Foreign key relationship between Employee and Department
                .OnDelete(DeleteBehavior.Restrict);     // Restrict deletion of department if employees exist
        }
    }
}
