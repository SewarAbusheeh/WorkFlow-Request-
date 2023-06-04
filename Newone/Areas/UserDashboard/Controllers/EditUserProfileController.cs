﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public class EditUserProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        private AppDbContext db;
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private IWebHostEnvironment _hostEnvironment;
        public EditUserProfileController(UserManager<ApplicationUser> userManager, IWebHostEnvironment hostEnvironment,
            SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, AppDbContext _db
          )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _hostEnvironment = hostEnvironment;
            db = _db;
        }

        [HttpGet]

        [Authorize]
        public IActionResult EditUserProfile()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var s = _userManager.GetUserId(HttpContext.User);
            var user = db.Users.Where(a => a.Id == userId).SingleOrDefault();
        
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


         //   return View();
        }

        public IActionResult EditUserProfile(EditprofileViewModel Profile)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            // var s = _userManager.GetUserId(HttpContext.User);
            var user = db.Users.Where(a => a.Id == userId).SingleOrDefault();
            // var s1 = _userManager.FindByIdAsync(id);
            //  ApplicationUser user1 = _userManager.FindByIdAsync(Profile.Id);
            string filename = string.Empty;
            if (user == null)
            {
                return RedirectToAction("Index");
            }
            if (Profile.Pic != null)
            {
                string Uploads = Path.Combine(_hostEnvironment.WebRootPath, @"UserImg");
                filename = Profile.Pic.FileName;
                string fullpath = Path.Combine(Uploads, filename);
                Profile.Pic.CopyTo(new FileStream(fullpath, FileMode.Create));
            }
            user.Pic = filename;
            user.UserName = Profile.UserName;
            user.LastName = Profile.LastName;
            user.FirstName = Profile.FirstName;
            user.City = Profile.City;
            user.Aboutme = Profile.Aboutme;
            user.Domain = Profile.Domain;
            user.Hobbies = Profile.Hobbies;
            user.Gender = Profile.Gender;
            user.Facebook = Profile.Facebook;
            //Pic = Profile.Pic,
            //Userbackground = Profile.Userbackground,
            user.Address = Profile.Address;

            user.Twitter = Profile.Twitter;
            user.Glinked = Profile.Glinked;
            var res = _userManager.UpdateAsync(user);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
