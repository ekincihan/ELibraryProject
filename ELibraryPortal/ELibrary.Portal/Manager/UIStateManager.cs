using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ELibrary.Portal.Manager
{
    public static class UIStateManager
    {
        public static ApplicationUser CurrentMember
        {
            get
            {
                ApplicationUser currentMember = null; // HttpRequest .Session["CurrentMember"] as ApplicationUser;

                return currentMember;
            }

            //set
            //{
            //    HttpContext.Current.Session["CurrentMember"] = value;
            //}
        }
    }
}