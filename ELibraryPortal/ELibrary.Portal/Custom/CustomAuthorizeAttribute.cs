using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.Portal.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using ELibrary.Portal.Manager;

namespace ELibrary.Portal.Custom
{
    public class CustomAuthorizeAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
            var currentUser = UIStateManager.CurrentMember;

            if (currentUser == null)
            { 
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                    { "controller", "Account" },
                    { "action", "Index" }
                    });
            }
        }
    }
}
