using Microsoft.AspNetCore.Mvc;

namespace Study_Notion.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult course()
        {
            return View();
        }
    }
}
