using Microsoft.AspNetCore.Mvc;

namespace Study_Notion.Controllers
{
    public class SingUpController : Controller
    {
        public IActionResult signup()
        {
            return View();
        }
    }
}
