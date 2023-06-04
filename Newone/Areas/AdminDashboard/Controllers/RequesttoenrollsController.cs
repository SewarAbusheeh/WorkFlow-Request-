using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newone.Data;
using Newone.Models;

namespace Newone.Areas.AdminDashboard.Controllers
{
    [Area("AdminDashboard")]
    public class RequesttoenrollsController : Controller
    {
        private readonly AppDbContext _context;

        public RequesttoenrollsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AdminDashboard/Requesttoenrolls
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Requesttoenrolls.Include(r => r.LatestCourse).Include(r => r.User).OrderByDescending(r=>r.CreationT);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AdminDashboard/Requesttoenrolls/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requesttoenroll = await _context.Requesttoenrolls
                .Include(r => r.LatestCourse)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RequesttoenrollId == id);
            if (requesttoenroll == null)
            {
                return NotFound();
            }

            return View(requesttoenroll);
        }

        // GET: AdminDashboard/Requesttoenrolls/Create
        public IActionResult Create()
        {
            ViewData["LatestCourseId"] = new SelectList(_context.LatestCourses, "LatestCourseId", "CName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: AdminDashboard/Requesttoenrolls/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RequesttoenrollId,Mesage,CreationT,UserId,LatestCourseId")] Requesttoenroll requesttoenroll)
        {
            if (ModelState.IsValid)
            {
                _context.Add(requesttoenroll);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LatestCourseId"] = new SelectList(_context.LatestCourses, "LatestCourseId", "CName", requesttoenroll.LatestCourseId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", requesttoenroll.UserId);
            return View(requesttoenroll);
        }

        // GET: AdminDashboard/Requesttoenrolls/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requesttoenroll = await _context.Requesttoenrolls.FindAsync(id);
            if (requesttoenroll == null)
            {
                return NotFound();
            }
            ViewData["LatestCourseId"] = new SelectList(_context.LatestCourses, "LatestCourseId", "CName", requesttoenroll.LatestCourseId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", requesttoenroll.UserId);
            return View(requesttoenroll);
        }

        // POST: AdminDashboard/Requesttoenrolls/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RequesttoenrollId,Mesage,CreationT,UserId,LatestCourseId")] Requesttoenroll requesttoenroll)
        {
            if (id != requesttoenroll.RequesttoenrollId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(requesttoenroll);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RequesttoenrollExists(requesttoenroll.RequesttoenrollId))
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
            ViewData["LatestCourseId"] = new SelectList(_context.LatestCourses, "LatestCourseId", "CName", requesttoenroll.LatestCourseId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", requesttoenroll.UserId);
            return View(requesttoenroll);
        }

        // GET: AdminDashboard/Requesttoenrolls/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requesttoenroll = await _context.Requesttoenrolls
                .Include(r => r.LatestCourse)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RequesttoenrollId == id);
            if (requesttoenroll == null)
            {
                return NotFound();
            }

            return View(requesttoenroll);
        }

        // POST: AdminDashboard/Requesttoenrolls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var requesttoenroll = await _context.Requesttoenrolls.FindAsync(id);
            _context.Requesttoenrolls.Remove(requesttoenroll);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RequesttoenrollExists(int id)
        {
            return _context.Requesttoenrolls.Any(e => e.RequesttoenrollId == id);
        }
    }
}
