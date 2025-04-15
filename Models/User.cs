using System.ComponentModel.DataAnnotations;

namespace Study_Notion.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
