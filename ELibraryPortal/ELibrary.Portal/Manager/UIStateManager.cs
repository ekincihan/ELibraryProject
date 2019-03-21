using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using ELibrary.Portal.Helpers;

namespace ELibrary.Portal.Manager
{
    public static class UIStateManager
    {
        private static HttpContextAccessor _httpContextAccessor = new HttpContextAccessor();
        public static ApplicationUser CurrentMember
        {
            get
            {
                ApplicationUser currentMember = _httpContextAccessor.HttpContext.Session.Get<ApplicationUser>("CurrentUser");

                return currentMember;
            }
            set
            {
                _httpContextAccessor.HttpContext.Session.Set<ApplicationUser>("CurrentUser", value);
            }
        }
    }
}