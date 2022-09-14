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
    }
}
