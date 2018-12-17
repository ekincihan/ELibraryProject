using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELibrary.API.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIControllerBase : ControllerBase
    {
    }
}
