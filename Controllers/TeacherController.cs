
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentMIS.Models;

namespace StudentMIS.Controllers  
{  
    public class TeacherController : Controller  
    {  
        [HttpGet]
        public IActionResult Index(string username)   {  
            TeacherDataStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.TeacherDataStoreContext)) as TeacherDataStoreContext;  
            TeacherData stu=(TeacherData)context.GetTeacherDetails(username);

            // Course c=(Course)context.GetCourses();

            ViewData["username"]=stu.username;
            ViewData["id"]=stu.id;
            ViewData["courseId"]=stu.courseId;
            ViewData["semester"]=stu.semester;
            ViewData["year"]=stu.year;
            return View(context.GetCourses());  
        }

        [HttpPost]
        public IActionResult Index(int courseId,string title,string department,int credits) {
            TeacherDataStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.TeacherDataStoreContext)) as TeacherDataStoreContext;  
            context.AddCourse(courseId,title,department,credits);
            return View(context.GetCourses());
        }  

        [HttpGet]
        public IActionResult Edit(int courseId,string username) {
             Console.WriteLine(courseId);
            Console.WriteLine(username);
            TeacherDataStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.TeacherDataStoreContext)) as TeacherDataStoreContext;  
            Course c=context.GetCourseDetails(courseId);
            ViewData["courseId"]=c.courseId;
            ViewData["CourseTitle"]=c.title;
            ViewData["department"]=c.department;
            ViewData["credits"]=c.credits;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(int courseId,string title,string department,int credits) {
            TeacherDataStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.TeacherDataStoreContext)) as TeacherDataStoreContext;  
            context.UpdateCourse(courseId,title,department,credits);
            string url="/Teacher?username=teacher";
            return Redirect(url);
        }
        [HttpGet]
        public ActionResult HandleDelete(int courseId,string username) {
            Console.WriteLine(courseId);
            Console.WriteLine(username);
             TeacherDataStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.TeacherDataStoreContext)) as TeacherDataStoreContext;  
             context.DeleteCourse(courseId);
             string url="/Teacher?username=teacher";
             return Redirect(url);
        }
    }    
}