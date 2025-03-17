using Microsoft.AspNetCore.Mvc;

namespace Study_Notion.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult about()
        {
            return View();
        }
    }
}
