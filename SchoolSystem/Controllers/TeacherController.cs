using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Models.HR;
using SchoolSystem.Models;

namespace SchoolSystem.Controllers
{
    public class TeacherController : Controller
    {
        HRDatabaseContext dbContext = new HRDatabaseContext();
        public IActionResult Index()
        {
            List<Teacher> teachers = dbContext.Teachers.ToList();
            return View(teachers);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            Teacher teacher = this.dbContext.Teachers.Where(e => e.TeacherId == id).FirstOrDefault();
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View("Create",teacher);
        }
    }
}
