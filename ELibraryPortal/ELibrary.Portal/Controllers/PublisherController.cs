using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.Portal.Controllers
{
    public class PublisherController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(PublisherModel model)
        {
            return View();
        }
    }
}