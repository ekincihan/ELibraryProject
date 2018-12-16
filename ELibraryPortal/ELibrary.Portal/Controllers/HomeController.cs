using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.Portal.Manager;
using Microsoft.AspNetCore.Mvc;
using ELibrary.Portal.Models;
using Newtonsoft.Json;

namespace ELibrary.Portal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Test()
        {
            return View();
        }
    }

    public class Values
    {
         
    }
}
