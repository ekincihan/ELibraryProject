using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.Entities.Concrete;
using ELibrary.Portal.Manager;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ELibrary.Portal.Helpers;
using ELibrary.DAL.Concrete.EntityFramework;

namespace ELibrary.Portal.Controllers
{
    public class AccountController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(IHttpContextAccessor  httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

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
            

            if (responseSaving.IsSuccess && responseSaving.Value != null)
            {
                UIStateManager.CurrentMember = responseSaving.Value;
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
            return View(model);
        }
    }
}