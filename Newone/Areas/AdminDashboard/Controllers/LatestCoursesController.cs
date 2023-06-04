using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newone.Data;
using Newone.Models;
using Newone.Models.ViewModels;

namespace Newone.Areas.AdminDashboard.Controllers
{
    [Area("AdminDashboard")]
    public class LatestCoursesController : Controller
    {
        private readonly AppDbContext _context;

        private IWebHostEnvironment _hostEnvironment;
        public LatestCoursesController(AppDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // GET: AdminDashboard/LatestCourses
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.LatestCourses.Include(l => l.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AdminDashboard/LatestCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var latestCourse = await _context.LatestCourses
                .Include(l => l.Category)
                .FirstOrDefaultAsync(m => m.LatestCourseId == id);
            if (latestCourse == null)
            {
                return NotFound();
            }

            return View(latestCourse);
        }

        // GET: AdminDashboard/LatestCourses/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: AdminDashboard/LatestCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LatestCourseViewModel model)
        {
            string filename = string.Empty;
            string imgName = UploadNewFile(model);
            //if (model.CourseImg != null)
            //{
            //    string Uploads = Path.Combine(_hostEnvironment.WebRootPath, @"Img");
            //    filename = model.CourseImg.FileName;
            //    string fullpath = Path.Combine(Uploads, filename);
            //    model.CourseImg.CopyTo(new FileStream(fullpath, FileMode.Create));
            //}
            if (ModelState.IsValid)
            {
                LatestCourse course = new LatestCourse
                {
                    
                    CategoryId = model.CategoryId,
                    CourseDesc = model.CourseDesc,
                    CName = model.CName,
                 
                    IsActive = true,
                    IsDeleted = false,
                    Price = model.Price,
                    CourseImg = imgName,
                    
                    
                    Hours=model.Hours
                



                };
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", latestCourse.CategoryId);
            return View(model);
        }
        public string UploadNewFile(LatestCourseViewModel model)
        {
            string newFullImgName = null;
            if (model.CourseImg != null)
            {
                string fileRoot = Path.Combine(_hostEnvironment.WebRootPath, @"Img");
                string newFileName = Guid.NewGuid() + "_" + model.CourseImg.FileName; //هي بروبرتي جاهزه 
                string fullpath = Path.Combine(fileRoot, newFileName);
                using (var myNewFile = new FileStream(fullpath, FileMode.Create))
                {
                    model.CourseImg.CopyTo(myNewFile);
                }
                newFullImgName = @"Img/" + newFileName;
                return newFullImgName;
            }
            return newFullImgName;
        }

        // GET: AdminDashboard/LatestCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var latestCourse = await _context.LatestCourses.FindAsync(id);
            if (latestCourse == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", latestCourse.CategoryId);
            return View(latestCourse);
        }

        // POST: AdminDashboard/LatestCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LatestCourseId,CName,CourseDesc,CourseImg,Hours,Topic,Price,Place,Duration,CStart,blockQute,MoreDescription,CategoryId,CreationDate,IsDeleted,IsActive")] LatestCourse latestCourse)
        {
            if (id != latestCourse.LatestCourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(latestCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LatestCourseExists(latestCourse.LatestCourseId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", latestCourse.CategoryId);
            return View(latestCourse);
        }

        // GET: AdminDashboard/LatestCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var latestCourse = await _context.LatestCourses
                .Include(l => l.Category)
                .FirstOrDefaultAsync(m => m.LatestCourseId == id);
            if (latestCourse == null)
            {
                return NotFound();
            }

            return View(latestCourse);
        }

        // POST: AdminDashboard/LatestCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var latestCourse = await _context.LatestCourses.FindAsync(id);
            _context.LatestCourses.Remove(latestCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LatestCourseExists(int id)
        {
            return _context.LatestCourses.Any(e => e.LatestCourseId == id);
        }
    }
}
