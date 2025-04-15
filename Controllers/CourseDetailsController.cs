using Microsoft.AspNetCore.Mvc;
using Study_Notion.Models;
using System.Linq;

namespace Study_Notion.Controllers
{
    public class CourseDetailsController : Controller
    {
        private readonly AppDbContext _context;

        public CourseDetailsController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult CourseDetails(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course); // Pass course to view
        }
    }
}
