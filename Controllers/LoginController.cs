
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
    public class LoginController : Controller     
    {  
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Message"]="Student Login";
            return View();
        }

        [HttpGet]
        public IActionResult Teacher()
        {
            ViewData["Message"]="Teacher Login";
            return View();
        }

        [HttpGet]
        public IActionResult Admin()
        {
            ViewData["Message"]="Admin Login";
            return View();
        }
 
        [HttpPost]
        public  IActionResult Index(string username,string password)  
        {  
            LoginStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.LoginStoreContext)) as LoginStoreContext;  
            string name=(string)context.IsValidStudent(username,password);
            if(name!="Invalid") {
                ViewData["Message"]="Valid";
                    Response.Redirect($"/Student?username={name}");   
                }
            else 
                ViewData["Message"]="Invalid Username or Password";
            return View();  
        }  

        [HttpPost]
        public  IActionResult Teacher(string username,string password)  
        {  
            LoginStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.LoginStoreContext)) as LoginStoreContext;  
            string name=(string)context.IsValidTeacher(username,password);
            if(name!="Invalid") {
                ViewData["Message"]="Valid";
                    Response.Redirect($"/Teacher?username={name}");   
                }
            else 
                ViewData["Message"]="Invalid Username or Password";
            return View();  
        }  


         [HttpPost]
        public  IActionResult Admin(string username,string password)  
        {

            LoginStoreContext context = HttpContext.RequestServices.GetService(typeof(StudentMIS.Models.LoginStoreContext)) as LoginStoreContext;  
            if((bool)context.IsValidAdmin(username,password)) {
                ViewData["Message"]="Valid";
                    Response.Redirect("/StudentData");   
                }
            else 
                ViewData["Message"]="Invalid Username or Password";
            return View();  
 
        }  
    }  
}