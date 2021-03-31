
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
        public IActionResult Index(string username)  
        {  
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
        public IActionResult Index(int courseId,string title,string department,int credits)
        {
            TeacherDataStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.TeacherDataStoreContext)) as TeacherDataStoreContext;  
            context.AddCourse(courseId,title,department,credits);
            return View(context.GetCourses());
        }  
    }    
}