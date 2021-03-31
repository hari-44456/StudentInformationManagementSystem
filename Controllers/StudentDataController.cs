
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentMIS.Models;

namespace StudentMIS.Controllers  
{  
    public class StudentDataController : Controller  
    {  
        [HttpGet]
        public IActionResult Index() {  
            StudentDataStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.StudentDataStoreContext)) as StudentDataStoreContext;  
            ViewData["Message"]="FROM CONTROLLER";
            return View(context.GetAllStudents());  
        }  

        [HttpPost]
        public IActionResult Index(string prn,string name,string department,string currentYear) {
           StudentDataStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.StudentDataStoreContext)) as StudentDataStoreContext;  
           context.AddStudent(prn,name,department,currentYear);     
           return View(context.GetAllStudents());
        }

        public ActionResult HandleDelete(string prn) {
            StudentDataStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.StudentDataStoreContext)) as StudentDataStoreContext;  
           context.DeleteStudent(prn);     
           return View("Index",context.GetAllStudents());
        }

        [HttpGet]
        public IActionResult Edit(string prn) {
            StudentDataStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.StudentDataStoreContext)) as StudentDataStoreContext;       
           StudentData student = context.GetStudentDetails(prn);
           ViewData["prn"]=student.prn;
           ViewData["name"]=student.name;
           ViewData["department"]=student.department;
           ViewData["currentYear"]=student.currentYear;
           return View();
        }

        [HttpPost]
        public void Edit(string prn,string name,string department,string currentYear) {
            StudentDataStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.StudentDataStoreContext)) as StudentDataStoreContext;  
            context.UpdateStudent(prn,name,department,currentYear);     
            Response.Redirect("/StudentData");
        }

        public void Logout() {
            Response.Redirect("/Home");
        }
    }  
}