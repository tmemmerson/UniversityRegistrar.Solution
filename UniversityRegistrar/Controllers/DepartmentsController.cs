using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UniversityRegistrar.Models;

namespace UniversityRegistrar.Controllers
{
  public class DepartmentsController : Controller
  {
    private readonly UniversityRegistrarContext _db;
    public DepartmentsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Department> model = _db.Departments.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Department department)
    {
      _db.Departments.Add(department);
      _db.SaveChanges();
      return RedirectToIndex("Details", new { id = department.DepartmentId });
    }

    public ActionResult Details(int id)
    {
      var thisDepartment = _db.Departments
        .Include(departments => departments.Students)
        .ThenInclude(join => join.Student)
        .Include(departments => departments.Courses)
        .ThenInclude(join => join.Course)
        .FirstOrDefault(departments => departments.DepartmentId == id);
      return View(thisDepartment);
    }

    public ActionResult Edit(int id)
    {
      var thisDepartment = _db.Departments.FirstOrDefault(department => department.DepartmentId == id);
      return View(thisDepartment);
    }

    [HttpPost]
    public ActionResult Edit(Department department, int StudentId, int CourseId)
    {
      if (StudentId != 0)
      {
        _db.StudentDepartment.Add(new StudentDepartment() { StudentId = StudentId, DepartmentId = department.DepartmentId });
      }
      
      if(CourseId != 0)
      {
        _db.CourseDepartment.Add(new CourseDepartment() { CourseId = CourseId, DepartmentId = department.DepartmentId });
      }
      _db.Entry(department).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}

