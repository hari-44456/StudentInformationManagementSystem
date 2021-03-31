
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
    public class HelloController : Controller     
    {  

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Message"]="Student Login";
            return View();
        }

       
       [HttpPost]
        public IActionResult Index(string name)

        {
            Console.WriteLine(name);
            ViewData["Message"]="Student Login";
            return View();
        }
    }  
}