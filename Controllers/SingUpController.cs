using Microsoft.AspNetCore.Mvc;
using Study_Notion.Models;

namespace Study_Notion.Controllers
{
    public class SingUpController : Controller
    {
        private readonly AppDbContext _context;

        public SingUpController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Signup(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email is already registered.");
                    return View(user);
                }

                _context.Users.Add(user);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Registration successful! Please login.";
                return RedirectToAction("Login", "Login");
            }

            return View(user);
        }
    }
}
