using Microsoft.AspNetCore.Mvc;
using Study_Notion.Models;
using System.Linq;

namespace Study_Notion.Controllers
{
    public class CourseController : Controller
    {
        private readonly AppDbContext _context;

        public CourseController(AppDbContext context)
        {
            _context = context;
        }

        // Renamed method to avoid route conflict
        public IActionResult AllCourses()
        {
            var courses = _context.Courses.ToList();
            return View(courses); // This will load Views/Course/AllCourses.cshtml
        }
    }
}
