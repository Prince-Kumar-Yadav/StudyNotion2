using Microsoft.AspNetCore.Mvc;

namespace Study_Notion.Controllers
{
    public class ForgetPasswordController : Controller
    {
        public IActionResult forgetPassword()
        {
            return View();
        }
    }
}
