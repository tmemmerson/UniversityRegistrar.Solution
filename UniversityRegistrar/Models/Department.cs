using System.Collections.Generic;

namespace UniversityRegistrar.Models
{
  public class Department
  {
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public virtual ICollection<StudentDepartment> Students { get; set; }
    public virtual ICollection<CourseDeparment> Courses { get; set; }

    public Department()
    {
      this.Students = new HashSet<StudentDepartment>();
      this.Courses = new HashSet<CourseDeparment>();
    }
  }
}