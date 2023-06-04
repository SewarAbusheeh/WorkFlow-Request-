using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Areas.AdminDashoard.Controllers
{
    public class HomeController : Controller
    {
        [Area("AdminDashboard")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
