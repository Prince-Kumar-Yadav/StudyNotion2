using Microsoft.AspNetCore.Mvc;

namespace Study_Notion.Controllers
{
    public class StudentDashboardController : Controller
    {
        public IActionResult studentDashboard()
        {
            return View();
        }
    }
}
