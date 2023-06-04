using Newone.Data;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.ViewComponents
{

    public class LatestCourseViewComponent :ViewComponent
    {

        private AppDbContext db;
        public LatestCourseViewComponent(AppDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()

        {
            var data = db.LatestCourses;
            return View(data);
        }
    }
}
