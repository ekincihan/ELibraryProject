using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ELibrary.API.Base;
using ELibrary.API.Models;
using ELibrary.API.Security;
using ELibrary.API.Type;
using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ELibrary.API.Controllers
{
    [ApiController]
    [Route("api/Account")]
    [Produces("application/json")]
    [AllowAnonymous]
    public class AccountController : APIControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<AppIdentityRole> _roleManager;
        private readonly RoleValidator<AppIdentityRole> _roleValidator;
        private readonly IConfiguration _configuration;
        private IHostingEnvironment _hostingEnvironment;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<AppIdentityRole> roleManager,
            RoleValidator<AppIdentityRole> roleValidator,
        IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _roleManager = roleManager;
            _roleValidator = roleValidator;
        }

        [HttpPost("Login")]
        public async Task<Response<ApplicationUser>> Login([FromBody]LoginModel model)
        {
            var response = new Response<ApplicationUser>();
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                appUser.BearerToken = JWTAuth.Instance.GenerateJwtToken(model.Email, appUser);
                return new Response<ApplicationUser> { IsSuccess = true, Value = appUser };
            }

            return new Response<ApplicationUser> { IsSuccess = false, Message = "Kullanıcı Adı veya Şifre yanlış" };
        }

        [HttpPost("PortalLogin")]
        [Authorize(Roles ="admin")]
        public async Task<Response<ApplicationUser>> PortalLogin([FromBody]LoginModel model)
        {
            try
            {
                var response = new Response<ApplicationUser>();
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                    appUser.BearerToken = JWTAuth.Instance.GenerateJwtToken(model.Email, appUser);
                    return new Response<ApplicationUser> { IsSuccess = true, Value = appUser };
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
            }

            return new Response<ApplicationUser> { IsSuccess = false, Message = "Kullanıcı Adı veya Şifre yanlış" };
        }

        [HttpPost("Register")]
        public async Task<Response<ApplicationUser>> Register([FromBody]RegisterModel model)
        {
            try
            {
                var identityUser = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Name = model.Name,
                    Surname = model.Surname,
                    Gender = model.Gender,
                    Birthdate = model.Birthdate,
                };

                if (model.Id != Guid.Empty)
                {
                    var updatedEntity = _userManager.Users.SingleOrDefault(r => r.Id == model.Id.ToString());
                    updatedEntity.Name = model.Name;
                    updatedEntity.Surname = model.Surname;
                    updatedEntity.Birthdate = model.Birthdate;
                    updatedEntity.Email = model.Email;
                    updatedEntity.UserName = model.Email;
                    updatedEntity.NormalizedEmail = model.Email;
                    updatedEntity.PhoneNumber = model.PhoneNumber;
                    var update = await _userManager.UpdateAsync(updatedEntity);
                    return new Response<ApplicationUser>(updatedEntity);

                }
                else
                {
                    var result = await _userManager.CreateAsync(identityUser, model.Password);

                    if (result.Succeeded)
                    {
                        //string role = "basic user";
                        //await _userManager.AddToRoleAsync(identityUser, role);
                        //await _userManager.AddClaimAsync(identityUser, new System.Security.Claims.Claim("userName", identityUser.UserName));
                        //await _userManager.AddClaimAsync(identityUser, new System.Security.Claims.Claim("email", identityUser.Email));
                        //await _userManager.AddClaimAsync(identityUser, new System.Security.Claims.Claim("role", role));

                        var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                        appUser.BearerToken = JWTAuth.Instance.GenerateJwtToken(model.Email, appUser);
                        return new Response<ApplicationUser>(appUser);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }


        //[HttpPost("Uploadmage")]
        //public bool Update()
        //{

        //    HttpResponseMessage response = new HttpResponseMessage();
        //    var httpRequest = HttpContext.Request;
        //    var file = Request.Form.Files[0];
        //    string folderName = "Upload";
        //    string webRootPath = _hostingEnvironment.WebRootPath;
        //    //string newPath = Path.Combine(webRootPath, folderName);
        //    //AppFileFilterModel appFileFilterModel = new AppFileFilterModel
        //    //{
        //    //    AppFileModuleId = model.Id,
        //    //    ModuleType = API.Models.Enum.Enum.Module.UserThumbnail,
        //    //    //File = model.File
        //    //};


        //    return true;

        //}

    }
}