using Microsoft.AspNetCore.Mvc;
using SchoolSystem.Models.HR;
using SchoolSystem.Models;

namespace SchoolSystem.Controllers
{
    public enum SortDirection
    {
        Ascending,
        Descending
    }
    public class TeacherController : Controller
    {
        HRDatabaseContext dbContext = new HRDatabaseContext();
        public IActionResult Index(string SortField, string CurrentSortField, SortDirection SortDirection, string searhByName)
        {
            var teachers = getTeachers();
            if(!string.IsNullOrEmpty(searhByName))
                teachers = teachers.Where( e => e.TeacherName.ToLower().Contains(searhByName.ToLower())).ToList();
            return View(this.sortTeachers(teachers,SortField,CurrentSortField,SortDirection)); 
        }

        private List<Teacher> getTeachers()
        {
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
            return teachers;
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
        public IActionResult Edit(int Id)
        {
            Teacher teacher = this.dbContext.Teachers.Where(e => e.TeacherId == Id).FirstOrDefault();
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
        public IActionResult Delete(int Id)
        {
            Teacher teacher = this.dbContext.Teachers.Where(e => e.TeacherId == Id).FirstOrDefault();
            if (teacher != null)
            {
                dbContext.Teachers.Remove(teacher);
                dbContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        private List<Teacher> sortTeachers(List<Teacher> teachers, string sortField, string currentSortField, SortDirection sortDirection)
        {
            if(string.IsNullOrEmpty(sortField))
            {
                ViewBag.SortField = "TeacherName";
                ViewBag.SortDirection = SortDirection.Ascending;
            }
            else
            {
                if (currentSortField == sortField)
                    ViewBag.SortDireciton = sortDirection == SortDirection.Ascending ? SortDirection.Descending : SortDirection.Ascending;
                
                else
                    ViewBag.SortDirection = SortDirection.Ascending;
                ViewBag.SortField = sortField;
            }
            var propertyinfo = typeof(Teacher).GetProperty(ViewBag.SortField);
            if(ViewBag.SortDirection == SortDirection.Ascending)
                teachers = teachers.OrderBy(e => propertyinfo.GetValue(e,null)).ToList();
            else
                teachers = teachers.OrderByDescending(e => propertyinfo.GetValue(e, null)).ToList();
            return teachers;
        }
    }
}
