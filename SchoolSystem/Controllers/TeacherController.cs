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
            //List<Teacher> teachers = dbContext.Teachers.ToList();
            var teachers = (from Teacher in dbContext.Teachers
                            join Department in dbContext.Departments
                            on Teacher.TeacherDepartmentId equals Department.DepartmentId
                            select new Teacher
                            {
                                TeacherId = Teacher.TeacherId,
                                TeacherName = Teacher.TeacherName,
                                TeacherDoB = Teacher.TeacherDoB,
                                TeacherDoH = Teacher.TeacherDoH,
                                TeacherSalary = Teacher.TeacherSalary,
                                TeacherDepartmentId = Teacher.TeacherDepartmentId,
                                TeacherDepartmentName = Department.DepartmentName
                            }).ToList();
            return View(teachers);
        }
        public IActionResult Create()
        {
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Teacher model)
        {
            ModelState.Remove("TeacherId");
            ModelState.Remove("DepartmentId");
            ModelState.Remove("DepartmentName");
            if (ModelState.IsValid)
            {
                dbContext.Teachers.Add(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View();
        }
        public IActionResult Edit(int id)
        {
            Teacher teacher = this.dbContext.Teachers.Where(e => e.TeacherId == id).FirstOrDefault();
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View("Create",teacher);
        }
        [HttpPost]
        public IActionResult Edit(Teacher model)
        {
            ModelState.Remove("TeacherId");
            ModelState.Remove("DepartmentId");
            ModelState.Remove("DepartmentName");
            if (ModelState.IsValid)
            {
                dbContext.Teachers.Update(model);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Departments = this.dbContext.Departments.ToList();
            return View("Create",model);
        }
    }
}
