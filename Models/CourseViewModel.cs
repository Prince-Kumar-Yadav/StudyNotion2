using System.ComponentModel.DataAnnotations;

namespace Study_Notion.Models
{
    public class CourseViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public IFormFile ImageFile { get; set; }

        public IFormFile VideoFile { get; set; }
    }

}
