using Microsoft.AspNetCore.Mvc;

namespace SchoolSystem.Controllers
{
    public class SchoolController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
