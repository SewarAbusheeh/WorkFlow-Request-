using Newone.Data;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.ViewComponents
{
    public class ClientViewComponent :ViewComponent
    {
        private AppDbContext db;
        public ClientViewComponent(AppDbContext _db)
        {
            db = _db;
        }
        public IViewComponentResult Invoke()

        {
            var data = db.Clients.OrderByDescending(x => x.CreationDate).Take(6);
            return View(data);
        }
    }
}
