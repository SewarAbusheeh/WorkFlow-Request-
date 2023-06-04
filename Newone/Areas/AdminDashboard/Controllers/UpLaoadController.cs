using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newone.Data;
using Newone.Models;
using Newone.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Areas.AdminDashboard.Controllers
{
    [Area("AdminDashboard")]
    public class UpLaoadController : Controller
    {
       

        private AppDbContext db;
        private IWebHostEnvironment _hostEnvironment;

        public UpLaoadController(AppDbContext _db, IWebHostEnvironment hostEnvironment)
        {
            db = _db;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            
            return View(db.CourseLessons.ToList());
        }
        [HttpGet]
        public IActionResult Upload()
        {
            ViewData["LatestCourseId"] = new SelectList(db.LatestCourses, "LatestCourseId", "CName");
            return View();
        }
        [HttpPost]
        public IActionResult Upload(CourseLessonViewModel M)
        {
            string filename = string.Empty;


            //if (M.Contatnt != null)
            //{
            //    string Uploads = Path.Combine(_hostEnvironment.WebRootPath, @"Videos");
            //    filename = M.Contatnt.FileName;
            //    string fullpath = Path.Combine(Uploads, filename);
            //    M.Contatnt.CopyTo(new FileStream(fullpath, FileMode.Create));
            //    filename = @"Videos\" + filename;
            //}

            if (M.Contatnt != null)
            {
                //string Uploads = Path.Combine(_hostEnvironment.WebRootPath, "Videos");
                //filename = M.Contatnt.FileName;
                //string fullpath = Path.Combine(Uploads, filename);
                //M.Contatnt.CopyTo(new FileStream(fullpath, FileMode.Create));
                //  filename = @"Videos\" + filename;
                string Uploads = Path.Combine(_hostEnvironment.WebRootPath, @"Videos");
                filename = M.Contatnt.FileName;
                string fullpath = Path.Combine(Uploads, filename);
                M.Contatnt.CopyTo(new FileStream(fullpath, FileMode.Create));
                filename = @"Videos\" + filename;
            }
            //   filename = filename;
           
            filename = @"Videos\" + filename;
            CourseLesson C = new CourseLesson
            {
                CreationDate = DateTime.Now,
                Contatnt = filename,
                CTitle = M.CTitle,
                SerialNumber = M.SerialNumber,
                FilePath=M.FilePath,
                LatestCourseId = M.LatestCourseId,
                IsActive = true,
                IsDeleted = false
            };

            db.CourseLessons.Add(C);
            db.SaveChanges();
            //  var d = db.CourseLessons.ToList();

            return RedirectToAction("Index") ;
        }
    }
}
