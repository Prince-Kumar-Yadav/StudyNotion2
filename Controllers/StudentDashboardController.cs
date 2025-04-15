using Microsoft.AspNetCore.Mvc;
using Study_Notion.Models;
using System.Linq;

namespace Study_Notion.Controllers
{
    public class StudentDashboardController : Controller
    {
        private readonly AppDbContext _context;

        public StudentDashboardController(AppDbContext context)
        {
            _context = context;
        }

        // Always display the dashboard, even if user profile is null
        public IActionResult StudentDashboard()
        {


            return View();
        }

    }
}
