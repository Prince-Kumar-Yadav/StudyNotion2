namespace Study_Notion.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string ProfileImage { get; set; } = "/images/default-profile.png"; // or default image path
    }

}
