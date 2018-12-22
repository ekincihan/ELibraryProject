using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.Portal.Manager;
using Microsoft.AspNetCore.Mvc;
using ELibrary.Portal.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using ELibrary.Portal.Components;
using ELibrary.API.Models;

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
            return View(new AuthorModel());
        }
        [HttpPost]
        public IActionResult Test(AuthorModel model)
        {
            //AppFileUploadViewComponent component = new AppFileUploadViewComponent(new AppFileFilterModel());

            return View();
        }
    }

    public class Values
    {
         
    }
}
