using Microsoft.AspNetCore.Mvc;
using Newone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Areas.UserDashboard.Controllers
{
    public class CourseLessons : Controller
    {
        private AppDbContext db;
        public IActionResult Index()
        {
            return View();
        }
        public CourseLessons(AppDbContext _db)
        {
            db = _db;
        }
        public IActionResult Start(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Display = db.CourseLessons.Where(a => a.LatestCourseId == id);

            //  var d = db.CourseLessons.ToList();

            return View(Display);
        }
    }
}
