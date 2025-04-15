using System.ComponentModel.DataAnnotations;

namespace Study_Notion.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string ImagePath { get; set; }

        public string VideoPath { get; set; }

        [Required]
        public string Description { get; set; }
        
    }

}
