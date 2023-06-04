using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newone.Data;
using Newone.Models;

namespace Newone.Areas.AdminDashboard.Controllers
{
    [Area("AdminDashboard")]
    public class ApprovesController : Controller
    {
        private readonly AppDbContext _context;

        public ApprovesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AdminDashboard/Approves
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Approves.Include(a => a.LatestCourse).Include(a => a.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AdminDashboard/Approves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approve = await _context.Approves
                .Include(a => a.LatestCourse)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ApproveId == id);
            if (approve == null)
            {
                return NotFound();
            }

            return View(approve);
        }

        // GET: AdminDashboard/Approves/Create
        public IActionResult Create()
        {
            ViewData["LatestCourseId"] = new SelectList(_context.LatestCourses, "LatestCourseId", "CName");
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: AdminDashboard/Approves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ApproveId,CreationT,UserId,LatestCourseId")] Approve approve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(approve);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LatestCourseId"] = new SelectList(_context.LatestCourses, "LatestCourseId", "CName", approve.LatestCourseId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", approve.UserId);
            return View(approve);
        }

        // GET: AdminDashboard/Approves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approve = await _context.Approves.FindAsync(id);
            if (approve == null)
            {
                return NotFound();
            }
            ViewData["LatestCourseId"] = new SelectList(_context.LatestCourses, "LatestCourseId", "CName", approve.LatestCourseId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", approve.UserId);
            return View(approve);
        }

        // POST: AdminDashboard/Approves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ApproveId,CreationT,UserId,LatestCourseId")] Approve approve)
        {
            if (id != approve.ApproveId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(approve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApproveExists(approve.ApproveId))
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
            ViewData["LatestCourseId"] = new SelectList(_context.LatestCourses, "LatestCourseId", "CName", approve.LatestCourseId);
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", approve.UserId);
            return View(approve);
        }

        // GET: AdminDashboard/Approves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approve = await _context.Approves
                .Include(a => a.LatestCourse)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ApproveId == id);
            if (approve == null)
            {
                return NotFound();
            }

            return View(approve);
        }

        // POST: AdminDashboard/Approves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var approve = await _context.Approves.FindAsync(id);
            _context.Approves.Remove(approve);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApproveExists(int id)
        {
            return _context.Approves.Any(e => e.ApproveId == id);
        }
        public IActionResult Approve(int id)
        {
            //  var Data = _context.Requesttoenrolls.Where(a=>a.RequesttoenrollId==id && a.User)

            //var L =  _context.Requesttoenrolls
            // .Include(r => r.LatestCourse)
            // .Include(r => r.User)
            var d = _context.Requesttoenrolls.Where(a => a.RequesttoenrollId == id).SingleOrDefault();
            // var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var check = _context.Approves.Where(a => a.LatestCourseId == d.LatestCourseId && a.UserId == d.UserId);
            if (check.Any())
            {
                ViewBag.err = "already you approved ";
                return View("Approve");
            }
            else
            {
                Approve a = new Approve
                {
                    CreationT = DateTime.Now,
                    LatestCourseId = d.LatestCourseId,
                    UserId = d.UserId
                    //  UserId= requesttoenroll.
                    // LatestCourseId= requesttoenroll.
                };
                _context.Approves.Add(a);
                _context.Requesttoenrolls.Remove(d);
                _context.SaveChanges();
            }
           
           
            // .FirstOrDefaultAsync(m => m.RequesttoenrollId == id);
           
           
         //   _context.Requesttoenrolls.Remove(d);
           
            return RedirectToAction("Index" ,"Approves");
        }
    }
}
