
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
        public IActionResult Index()  
        {  
            StudentDataStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.StudentDataStoreContext)) as StudentDataStoreContext;  
            ViewData["Message"]="FROM CONTROLLER";
            return View(context.GetAllStudents());  
        }  

        [HttpPost]
        public IActionResult Index(string prn,string name,string department,string currentYear)
        {
           StudentDataStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.StudentDataStoreContext)) as StudentDataStoreContext;  
           context.AddStudent(prn,name,department,currentYear);     
           return View(context.GetAllStudents());
        }

        public void Logout() 
        {
            Response.Redirect("/Home");
        }
    }  
}