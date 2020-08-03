using System.Collections.Generic;
using System;

namespace UniversityRegistrar.Models
{
  public class Student
  {
    public string Name { get; set;}
    public int StudentId { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public ICollection<StudentCourse> Courses { get; }

    public Student()
    {
      this.Courses = new HashSet<StudentCourse>();
    }

  }
}