using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newone.Data;
using Newone.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace Newone.Areas.AdminDashboard.Controllers
{
 // [Authorize(Roles = "Administrator")]
    [Area("AdminDashboard")]
    public class ComingCoursesController : Controller
    {
        private readonly AppDbContext _context;

        public ComingCoursesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AdminDashboard/ComingCourses
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ComingCourses.Include(c => c.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AdminDashboard/ComingCourses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comingCourse = await _context.ComingCourses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.ComingCourseId == id);
            if (comingCourse == null)
            {
                return NotFound();
            }

            return View(comingCourse);
        }

        // GET: AdminDashboard/ComingCourses/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View();
        }

        // POST: AdminDashboard/ComingCourses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComingCourseId,CName,CourseDesc,CourseImg,Hours,Price,StartDate,CategoryId,CreationDate,IsDeleted,IsActive")] ComingCourse comingCourse)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comingCourse);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", comingCourse.CategoryId);
            return View(comingCourse);
        }

        // GET: AdminDashboard/ComingCourses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comingCourse = await _context.ComingCourses.FindAsync(id);
            if (comingCourse == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", comingCourse.CategoryId);
            return View(comingCourse);
        }

        // POST: AdminDashboard/ComingCourses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComingCourseId,CName,CourseDesc,CourseImg,Hours,Price,StartDate,CategoryId,CreationDate,IsDeleted,IsActive")] ComingCourse comingCourse)
        {
            if (id != comingCourse.ComingCourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comingCourse);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComingCourseExists(comingCourse.ComingCourseId))
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
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", comingCourse.CategoryId);
            return View(comingCourse);
        }

        // GET: AdminDashboard/ComingCourses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comingCourse = await _context.ComingCourses
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.ComingCourseId == id);
            if (comingCourse == null)
            {
                return NotFound();
            }

            return View(comingCourse);
        }

        // POST: AdminDashboard/ComingCourses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comingCourse = await _context.ComingCourses.FindAsync(id);
            _context.ComingCourses.Remove(comingCourse);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComingCourseExists(int id)
        {
            return _context.ComingCourses.Any(e => e.ComingCourseId == id);
        }
    }
}
