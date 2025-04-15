using Microsoft.EntityFrameworkCore;
using Study_Notion.Models;
using System.Collections.Generic;

namespace Study_Notion
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }
        public object EnrolledCourses { get; internal set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

    }
}
