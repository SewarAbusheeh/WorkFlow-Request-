
using Microsoft.AspNetCore.Mvc;
using Newone.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.ViewComponents
{

    public class ArticleViewComponent : ViewComponent
    {
        private AppDbContext db;
        public ArticleViewComponent(AppDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()

        {
            var data = db.Articles.OrderByDescending(x => x.CreationDate).Take(3);
            return View(data);
        }
    }
}
