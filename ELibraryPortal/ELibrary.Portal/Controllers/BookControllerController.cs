using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.Portal.Controllers
{
    public class BookControllerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}