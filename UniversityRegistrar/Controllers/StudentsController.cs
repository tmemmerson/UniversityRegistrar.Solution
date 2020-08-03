using Microsoft.AspNetCore.Mvc;
using UniversityRegistrar.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace UniversityRegistrar.Controllers
{
  public class StudentsController : Controller
  {
    private readonly UniversityRegistrar _db;

    public StudentsController(UniversityRegistrarContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.Items.ToList());
    }

    public ActionResult Create()
    {
      return View();
    }

    []
  }
}