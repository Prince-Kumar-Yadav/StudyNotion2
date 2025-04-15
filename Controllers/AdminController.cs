using Microsoft.AspNetCore.Mvc;
using Study_Notion.Models;

namespace Study_Notion.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public AdminController(IWebHostEnvironment env, AppDbContext context)
        {
            _env = env;
            _context = context;
        }
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Dashboard(CourseViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string imgPath = null, videoPath = null;

            // Define the upload folders
            var imageUploadFolder = Path.Combine(_env.WebRootPath, "uploads", "images");
            var videoUploadFolder = Path.Combine(_env.WebRootPath, "uploads", "videos");

            // Create the folders if they don't exist
            if (!Directory.Exists(imageUploadFolder))
                Directory.CreateDirectory(imageUploadFolder);

            if (!Directory.Exists(videoUploadFolder))
                Directory.CreateDirectory(videoUploadFolder);

            // Save image file if provided
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var imgFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);
                var imgSavePath = Path.Combine(imageUploadFolder, imgFileName);
                using (var stream = new FileStream(imgSavePath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stream);
                }
                imgPath = "/uploads/images/" + imgFileName;
            }

            // Save video file if provided
            if (model.VideoFile != null && model.VideoFile.Length > 0)
            {
                var vidFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.VideoFile.FileName);
                var vidSavePath = Path.Combine(videoUploadFolder, vidFileName);
                using (var stream = new FileStream(vidSavePath, FileMode.Create))
                {
                    await model.VideoFile.CopyToAsync(stream);
                }
                videoPath = "/uploads/videos/" + vidFileName;
            }

            // Save course to database
            var course = new Course
            {
                Title = model.Title,
                Description = model.Description,
                ImagePath = imgPath,
                VideoPath = videoPath
            };

            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return RedirectToAction("ManageCourse", "Admin");
        }

        [HttpPost]
        public IActionResult Logout()
        {
            // Clear session or authentication cookie here
            return RedirectToAction("Login", "Login");
        }

        [HttpGet]
        public IActionResult ManageCourse()
        {
            var courses = _context.Courses.ToList();
            return View(courses);
        }

        [HttpGet]
        public IActionResult EditCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();

            var model = new CourseViewModel
            {
                Title = course.Title,
                Description = course.Description
            };
            ViewBag.CourseId = course.Id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditCourse(int id, CourseViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();

            course.Title = model.Title;
            course.Description = model.Description;

            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var imgFolder = Path.Combine(_env.WebRootPath, "uploads", "images");
                if (!Directory.Exists(imgFolder)) Directory.CreateDirectory(imgFolder);

                var imgFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.ImageFile.FileName);
                var imgPath = Path.Combine(imgFolder, imgFileName);
                using (var stream = new FileStream(imgPath, FileMode.Create))
                {
                    await model.ImageFile.CopyToAsync(stream);
                }
                course.ImagePath = "/uploads/images/" + imgFileName;
            }

            if (model.VideoFile != null && model.VideoFile.Length > 0)
            {
                var vidFolder = Path.Combine(_env.WebRootPath, "uploads", "videos");
                if (!Directory.Exists(vidFolder)) Directory.CreateDirectory(vidFolder);

                var vidFileName = Guid.NewGuid().ToString() + Path.GetExtension(model.VideoFile.FileName);
                var vidPath = Path.Combine(vidFolder, vidFileName);
                using (var stream = new FileStream(vidPath, FileMode.Create))
                {
                    await model.VideoFile.CopyToAsync(stream);
                }
                course.VideoPath = "/uploads/videos/" + vidFileName;
            }

            _context.Courses.Update(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("ManageCourse");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = _context.Courses.FirstOrDefault(c => c.Id == id);
            if (course == null) return NotFound();

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction("ManageCourse");
        }


    }

}
