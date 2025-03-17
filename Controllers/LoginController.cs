using Microsoft.AspNetCore.Mvc;

namespace Study_Notion.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult login()
        {
            return View();
        }
    }
}
