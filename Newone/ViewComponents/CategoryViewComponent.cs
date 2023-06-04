
using Microsoft.AspNetCore.Mvc;
using Newone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        private AppDbContext db;
        public CategoryViewComponent(AppDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()

        {
            var data = db.Categories.OrderByDescending(x => x.CreationDate).Take(3);
            return View(data);
        }
    }
}
