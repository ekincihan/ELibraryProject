using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.Portal.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<string> nav = new List<string>();
            nav.Add(ViewContext.RouteData.Values["controller"].ToString());
            nav.Add(ViewContext.RouteData.Values["Action"].ToString());

            return View(nav);
        }
    }
}
