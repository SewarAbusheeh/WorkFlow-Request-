using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newone.Data;
using Newone.Models;
using Newone.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Newone.Areas.UserDashboard.Controllers
{
    [Area("UserDashboard")]
    public class HomeController : Controller
    {
        private AppDbContext db;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private IWebHostEnvironment _hostEnvironment;
        public HomeController(UserManager<ApplicationUser> userManager, IWebHostEnvironment hostEnvironment,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager , AppDbContext _db
          )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _hostEnvironment = hostEnvironment;
            db = _db;
        }

        // public object Session { get; private set; }

       
        public IActionResult Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var User1 = db.Users.Where(a => a.Id == userId).SingleOrDefault();
            if (User1 == null)
            {
                return RedirectToAction("Index");
            }


           // var res = _userManager.Users.SingleOrDefault(User1);
            return View(User1);
        }
        public IActionResult Calender()
        {
           
           


            // var res = _userManager.Users.SingleOrDefault(User1);
            return View();
        }
        [HttpGet]
        [Authorize]
        public IActionResult EditPUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var s = _userManager.GetUserId(HttpContext.User);
            var user = db.Users.Where(a => a.Id == userId).SingleOrDefault();
            // var  user = _userManager.
            //EditprofileViewModel moddel = new EditprofileViewModel
            //{
            //    Id = userId,
            //    UserName = user.UserName,
            //    Eamil = user.Email

            //};
            //return View();

            // ApplicationUser Us = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            else
            {

                EditprofileViewModel model = new EditprofileViewModel
                {

                    Id = userId,
                    UserName = user.UserName,
                    LastName = user.LastName,
                    FirstName = user.FirstName,
                    Eamil = user.Email,
                    City = user.City,
                    Aboutme = user.Aboutme,
                    Domain = user.Domain,
                    Hobbies = user.Hobbies,
                    Gender = user.Gender,
                    Facebook = user.Facebook,
                    //    Pic = Profile.Pic,
                    //  Userbackground = Profile.Userbackground,
                    Address = user.Address,

                    Twitter = user.Twitter,
                    Glinked = user.Glinked



                };
                return View(model);
            }
        }
            //ApplicationUser appUser = new ApplicationUser();
            ////appUser = _userManager.FindByIdAsync(id);
            //// var CurentUser = db.Users.Where(a => a.Id == userId).SingleOrDefault();
            //// EditprofileViewModel e = new EditprofileViewModel();
            ////  var User = ApplicationUser.FindByIdAsync(id);
            ////var model = new EditprofileViewModel
            ////{
            ////    Id =userId 

            ////};
            //return View();
            //}
            //public string UploadNewFile(EditprofileViewModel model)
            //{
            //    string newFullImgName = null;
            //    if (model.Pic != null)
            //    {
            //        string fileRoot = Path.Combine(_hostEnvironment.WebRootPath, @"UserImg");
            //        string newFileName = Guid.NewGuid() + "_" + model.Pic.FileName; //هي بروبرتي جاهزه 
            //        string fullpath = Path.Combine(fileRoot, newFileName);
            //        using (var myNewFile = new FileStream(fullpath, FileMode.Create))
            //        {
            //            model.Pic.CopyTo(myNewFile);
            //        }
            //        newFullImgName = @"UserImg/" + newFileName;
            //        return newFullImgName;
            //    }
            //    return newFullImgName;
            //}
            //[HttpPost]
            //public IActionResult EditPUser(ApplicationUser a )
            //{
            //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //    // var CurrentUser = db.Users.Where(a => a.Id == userId).SingleOrDefault();
            //    // EditprofileViewModel e = new EditprofileViewModel();
            //    //  var User = ApplicationUser.FindByIdAsync(id);
            //    //var model = new EditprofileViewModel
            //    //{
            //    var s = _userManager.GetUserId(HttpContext.User);

            //    //    Id =userId 

            //    //};
            //    return View(userId);
            //}
            //[HttpPost]
            //public IActionResult EditPUser(EditprofileViewModel Profile )
            //{
            //    string filename= string.Empty;
            //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //    // var s = _userManager.GetUserId(HttpContext.User);
            //    var user = db.Users.Where(a => a.Id == userId).SingleOrDefault();
            //    // var s1 = _userManager.FindByIdAsync(id);
            //    //  ApplicationUser user1 = _userManager.FindByIdAsync(Profile.Id);
            //    if (user == null)
            //    {
            //        return RedirectToAction("Index");
            //    }

            //    string imgName = UploadNewFile(Profile);
            //    user.UserName = Profile.UserName;
            //        user.LastName = Profile.LastName;
            //        user.FirstName = Profile.FirstName;
            //        user.City = Profile.City;
            //        user.Aboutme = Profile.Aboutme;
            //        user.Domain = Profile.Domain;
            //        user.Hobbies = Profile.Hobbies;
            //        user.Gender = Profile.Gender;
            //        user.Facebook = Profile.Facebook;
            //        //Pic = Profile.Pic,
            //        //Userbackground = Profile.Userbackground,
            //        user.Address = Profile.Address;

            //        user.Twitter = Profile.Twitter;
            //        user.Glinked = Profile.Glinked;
            //        var res = _userManager.UpdateAsync(user);
            //        db.SaveChanges();

            //       return RedirectToAction("Index");

            //        //   db.Entry(user).State=System.Data.UpdateRowSource.
            //        //ApplicationUser U = new ApplicationUser
            //        //{
            //        //    UserName = Profile.UserName,
            //        //    LastName = Profile.LastName,
            //        //    FirstName = Profile.FirstName,
            //        //    Gender = Profile.Gender,
            //        //    Facebook = Profile.Facebook,
            //        //    //Pic = Profile.Pic,
            //        //    //Userbackground = Profile.Userbackground,
            //        //    Address = Profile.Address,
            //        //    City = Profile.City,
            //        //    Twitter = Profile.Twitter,
            //        //    Glinked = Profile.Glinked,
            //        //    Aboutme = Profile.City,

            //        //};









        }
}
