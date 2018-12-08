using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Models;
using ELibrary.API.Type;
using ELibrary.Portal.Manager;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ELibrary.Portal.Controllers
{
    public class PublisherController : Controller
    {
        public ActionResult Index()
        {
            var publishers = JsonConvert.DeserializeObject<Response<List<PublisherModel>>>(UiRequestManager.Instance.Get("Publisher","List"));

            return View(publishers);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PublisherModel model)
        {
            try
            {
                Response<PublisherModel> responseSaving = JsonConvert.DeserializeObject<Response<PublisherModel>>(UiRequestManager.Instance.Post("Publisher", "Add", JsonConvert.SerializeObject(model)));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return RedirectToAction("Index");
        }
    }
}