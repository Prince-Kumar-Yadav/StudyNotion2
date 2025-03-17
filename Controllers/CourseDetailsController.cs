using Microsoft.AspNetCore.Mvc;

namespace Study_Notion.Controllers
{
    public class CourseDetailsController : Controller
    {
        public IActionResult courseDetails()
        {
            return View();
        }
    }
}
