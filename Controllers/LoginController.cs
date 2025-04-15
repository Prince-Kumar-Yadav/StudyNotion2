using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Study_Notion.Models;
using System.Linq;

namespace Study_Notion.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        // ✅ Only this constructor should exist
        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            if (email == "admin@gmail.com" && password == "123456")
            {
                // Redirect to Admin dashboard
                return RedirectToAction("Dashboard", "Admin");
            }

            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                // Redirect to Course page for regular user
                return RedirectToAction("AllCourses", "Course");
            }

            TempData["ErrorMessage"] = "Invalid email or password.";
            return View();
        }
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(); // If using authentication middleware
            return RedirectToAction("Login", "Login");
        }

    }
}
