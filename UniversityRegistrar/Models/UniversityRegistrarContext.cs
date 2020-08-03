using Microsoft.EntityFrameworkCore;

namespace UniversityRegistrar.Models
{
  public class UniversityRegistrarContext : DbContext
  {
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<StudentCourse> StudentCourse { get; set; }
    public virtual DbSet<Department> Department { get; set; }
    public virtual DbSet<StudentDepartment> StudentDepartment { get; set; }
    public virtual DbSet<CourseDepartment> CourseDepartment { get; set; }
    public UniversityRegistrarContext(DbContextOptions options) : base(options) {}
  }
}