using Newone.Models;
using Newone.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Newone.Areas.AdminDashboard.Controllers
{
    [Area("AdminDashboard")]
   

    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        public AdminController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        // [Authorize(Roles = "Admin")]
       // [Authorize(Roles = "Administrator")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
       // [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // HttpContext.Session.Setstring("U",)
            if (ModelState.IsValid)
            {
                if (User.IsInRole("Admin")) { }
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.Rememberme, false);
                if (result.Succeeded)
                {
                 
                    return RedirectToAction("Index", "Home", new { area = "AdminDashboard" });
                    //HttpContext.Session.Setstring("Admin");
                }
                ModelState.AddModelError("", "Invalid user or password");
                return View(model);
            }
            return View(model);
        }
        public async Task<IActionResult> Logout()
        {
           // HttpContext.Session.Clear();
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]

        
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            IdentityRole role = new IdentityRole
            {
                Name = model.RoleName
            };

            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }
            foreach (var err in result.Errors)
            {
                ModelState.AddModelError(err.Code, err.Description);
            }
            return View(model);

        }

    }
    
}
