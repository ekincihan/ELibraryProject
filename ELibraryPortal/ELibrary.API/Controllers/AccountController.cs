﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ELibrary.API.Base;
using ELibrary.API.Models;
using ELibrary.API.Security;
using ELibrary.API.Type;
using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ELibrary.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class AccountController : APIControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _configuration;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public async Task<JsonResult> Login(LoginModel model)
        {
            var response = new Response<ApplicationUser>();
            var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                appUser.BearerToken = JWTAuth.Instance.GenerateJwtToken(model.Email, appUser);
                return new JsonResult(response, new Newtonsoft.Json.JsonSerializerSettings { PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None });
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }
    }
}