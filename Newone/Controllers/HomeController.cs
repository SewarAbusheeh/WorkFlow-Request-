using Microsoft.AspNetCore.Mvc;
using Newone.Data;
using Newone.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using X.PagedList;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Newone.Models.ViewModels;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Newone.Controllers
{
    public class HomeController : Controller
    {
        public static int De;
        private AppDbContext db;
        private IWebHostEnvironment _hostEnvironment;

        public object Session { get; private set; }

        public HomeController(AppDbContext _db, IWebHostEnvironment hostEnvironment)
        {
            db = _db;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ComingCIndex1(int page = 1)
        {

            var data = db.ComingCourses.OrderByDescending(x => x.CreationDate).ToPagedList(page, 2);
            //.OrderByDescending(x => x.CreationDate).ToPagedList(page, 2)
            //   var data1 = db.ComingCourses.OrderByDescending(x => x.CreationDate).ToPagedList(page??1 ,2);
            return View(data);
        }
        [HttpGet]
        public IActionResult ComingCDetails(int? id)
        {
            var data = db.ComingCourses.Find(id);

            return View(data);

        }
     
        [HttpGet]
        public IActionResult send()
        {
            return View();
        }


        public IActionResult send(Contact contact)
        {
            if (ModelState.IsValid)
            {
                //        // obj mail 
                //        // كلاس يمثل رساله
                var mail = new MailMessage();
                //        //  معطيات تسجيل الدخول بغرض ارسال الرسائل من خلاله يت تحويل الرسائل  
                //        // نتورك كردنشل ينتظر الايميل والباسورد
                //        //   الايميل الذي سوف نرسل من خلاله اللي رح اقوم بالارسال من خلاله 
                var Loginfo = new NetworkCredential("sewarabusheeh@gmail.com", "lkkwzsvegzkffbxz ");


                //        // مين هو المرسل 
                mail.From = new MailAddress(contact.Email);
                //        // الوجهه 
                mail.To.Add(new MailAddress("sewarabusheeh@gmail.com"));

                mail.Subject = contact.Subject;
                mail.IsBodyHtml = true;
                string body = "Name :" + contact.Name + "<br>" +
                               "Email: <br> <b> " + contact.Email + "<br>" +
                              "Subject:" + contact.Subject + "<br>" +
                               "Message: <b>" + contact.Message + "<br>";
                mail.Body = body;
                //     smtpClient بدي ارسل ايميل ب دوت نت عن طريق   واحدد الهوست 
                //        //the port of gmail is 587
                var smtpClient = new SmtpClient("smtp.gmail.com", 587);
                //        // الجميل يسمح بالوضع الامن   ؟؟ البيانات محميه عند تحويل  من البراوسر الى سيرفر
                //        // smtp deal with ssl
                smtpClient.EnableSsl = true;
                //        //معطيات الارسال 

                smtpClient.Credentials = Loginfo;
                smtpClient.Send(mail);
                db.Contacts.Add(contact);
               db.SaveChanges();
                return RedirectToAction("Index");

            }

            ViewBag.err = "Fill The Info";
            return View("send");
        }
        [HttpGet]
        public IActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Search(string CateName)
        {
            //var result = db.Categories.Where(a => a.CategoryName.Contains(CateName)).ToList();
            var R = db.LatestCourses.Where(s => s.Category.CategoryName.Contains(CateName)
             || s.CName.Contains(CateName)
             || s.CourseDesc.Contains(CateName)).ToList();


            return View(R);
        }
        public IActionResult CategoryDisplay(int ID, int Page = 1)
        {
            //  var result = db.Categories.Where(a => a.CategoryId == ID );
            //  var data = db.ComingCourses.OrderByDescending(x => x.CreationDate).ToPagedList(Page, 2);
            // var R = db.Courses.Where(s => s.Category.CategoryName.Contains(CD)).ToList();
            //   var data = db.ComingCourses.OrderByDescending(x => x.CreationDate).ToPagedList(page, 2);
            //  if (result!= null)-
            // {
            var R = db.LatestCourses.Where(s => s.Category.CategoryId == ID).OrderByDescending(x => x.CreationDate).ToPagedList(Page,2);
            return View(R);
            // }

            //   return View(result);
        }
        [HttpGet]
        public IActionResult CDetails(int? id)
        {

            var data = db.LatestCourses.Find(id);
            //  Session["id"] = id;
            if (id == null)
            {
                return NotFound();
            }
            HttpContext.Session.SetString("id", id.ToString());

            //  Session["id"] = id;

            return View(data);
        }
        [HttpGet]
        [Authorize]
        public IActionResult Enroll()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Enroll(string Mesage, int id )
        {
            De = id;
            //var check =db.Requesttoenrolls.Where(a=>a.CourseId==),
            // //  var UserId = User.Identity.
            // var userEmail = User.FindFirstValue(ClaimTypes.Email); // will give the user's Email
          
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var chack = db.Requesttoenrolls.Where(a => a.UserId == userId && a.LatestCourseId == id);
            if (chack.Any() )
            {
                ViewBag.err = " Opps !You already request ";
            }
            else{

                //   var LatestCourseId =  HttpContext.Session.GetString("id") ;
                Requesttoenroll r = new Requesttoenroll
                {
                    Mesage = Mesage,
                    CreationT = DateTime.Now,
                    LatestCourseId = id,
                    UserId = userId
                };
                db.Requesttoenrolls.Add(r);
                db.SaveChanges();
                ViewBag.err = "Your request is sent Wait Approve ";
            }
            return View();

        }
        [HttpGet]
        [Authorize]
        public IActionResult RequestByUser()
        {
            //var appDbContext = Include(r => r.LatestCourse).Include(r => r.User).OrderByDescending(r => r.CreationT);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Request = db.Requesttoenrolls.Where(a => a.UserId == userId).ToList();
            return View(Request);
        }
        //[HttpGet]
        //[Authorize]
        public IActionResult CoursesForuser()
        {
            //var appDbContext = Include(r => r.LatestCourse).Include(r => r.User).OrderByDescending(r => r.CreationT);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var Request = db.Approves.Where(a => a.UserId == userId);
            return View(Request.ToList());
        }
        //[HttpGet]
        //public IActionResult RequestDetails(int De)
        //{
        //    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

        //    var Details = db.Requesttoenrolls.Find(De);
        //    return View(Details);
        //}
        public async Task<IActionResult> DetailsR(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var requesttoenroll = await db.Requesttoenrolls
                .Include(r => r.LatestCourse)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RequesttoenrollId == id);
            if (requesttoenroll == null)
            {
                return NotFound();
            }

            return View(requesttoenroll);
        }
        public async Task<IActionResult> CoursesUserDetail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var approve = await db.Approves
                .Include(a => a.LatestCourse)
                .Include(a => a.User)
                .FirstOrDefaultAsync(m => m.ApproveId == id);
            if (approve == null)
            {
                return NotFound();
            }

            return View(approve);
        }
        public IActionResult Start(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Display  =  db.CourseLessons.Where(a => a.LatestCourseId == id);

          //  var d = db.CourseLessons.ToList();

            return View(Display);
        }
        //[HttpGet]
        //public IActionResult Upload(  )
        //{
        //    ViewData["LatestCourseId"] = new SelectList(db.LatestCourses, "LatestCourseId", "CName");
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Upload(CourseLessonViewModel M)
        //{
        //    string filename = string.Empty;


        //    if (M.Contatnt != null)
        //    {
        //        string Uploads = Path.Combine(_hostEnvironment.WebRootPath, @"Videos");
        //        filename = M.Contatnt.FileName;
        //        string fullpath = Path.Combine(Uploads, filename);
        //        M.Contatnt.CopyTo(new FileStream(fullpath, FileMode.Create));
        //        filename = @"Videos\" + filename;
        //    }
          
            
        //    CourseLesson C = new CourseLesson
        //    {
        //        CreationDate = DateTime.Now,
        //        Contatnt = filename,
        //        CTitle = M.CTitle,
        //        SerialNumber = M.SerialNumber,
        //        LatestCourseId = M.LatestCourseId,
        //        IsActive = true,
        //        IsDeleted = false
        //    };

        //    db.CourseLessons.Add(C);
        //    db.SaveChanges();
        //    //  var d = db.CourseLessons.ToList();

        //    return View(C);
        //}



    }
}
