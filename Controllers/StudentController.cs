
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
    public class StudentController : Controller  
    {  
        public IActionResult Index(string username)  
        {  
            StudentStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.StudentStoreContext)) as StudentStoreContext;  
            StudentData stu=(StudentData)context.GetStudentDetails(username);

            ViewData["name"]=stu.name;
            ViewData["prn"]=stu.prn;
            ViewData["department"]=stu.department;
            ViewData["currentYear"]=stu.currentYear;
            return View();  
        }  
    }    
}