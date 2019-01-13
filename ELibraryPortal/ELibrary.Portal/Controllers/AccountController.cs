using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.Entities.Concrete;
using ELibrary.Portal.Manager;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ELibrary.Portal.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View(new LoginModel());
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            if (!TryValidateModel(model))
                return View(model);
            Response<ApplicationUser> responseSaving = JsonConvert.DeserializeObject<Response<ApplicationUser>>(UiRequestManager.Instance.Post("Account", "PortalLogin", JsonConvert.SerializeObject(model)));

            return RedirectToAction("Index", "Home");
        }
    }
}