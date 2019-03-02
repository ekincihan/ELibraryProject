using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.Portal.Helpers;
using ELibrary.Entities.Concrete;

namespace ELibrary.Portal.Custom
{
    [CustomAuthorizeAttribute]
    public class UIControllerBase : Controller
    {
    }
}
