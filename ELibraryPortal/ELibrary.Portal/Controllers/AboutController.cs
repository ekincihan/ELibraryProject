using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Models;
using Microsoft.AspNetCore.Mvc;


namespace ELibrary.Portal.Controllers
{
    public class AboutController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Save(Guid? id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Save(AboutModel model)
        {
            return View();
        }
    }
}
