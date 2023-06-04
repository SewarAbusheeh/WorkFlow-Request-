using Newone.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Data
{
    public class AppDbContext:IdentityDbContext<ApplicationUser> //Id...Context OF ApplicationUser
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)

        {
        }
      
       public DbSet<Contact> Contacts { get; set; }
        public DbSet<Category> Categories { get; set; }
      
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
       public DbSet<Article> Articles { get; set; }

        public DbSet<Approve> Approves { get; set; }
        public DbSet<ComingCourse> ComingCourses { get; set; }
        public DbSet<Client> Clients { get; set; }
   
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Requesttoenroll> Requesttoenrolls { get; set; }
        public DbSet<LatestCourse> LatestCourses { get; set; }
        public DbSet<CourseLesson> CourseLessons { get; set; }






    }
}
