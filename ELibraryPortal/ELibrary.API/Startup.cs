using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using ELibrary.API.Configuration;
using ELibrary.DAL.Abstract;
using ELibrary.DAL.Concrete.EntityFramework;
using ELibrary.Entities.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using AutoMapper;
using ELibrary.Core.DataAccess.MongoDB;
using ELibrary.DAL.Concrete.MongoDB;

namespace ELibrary.API
{
    public class Startup
    {
        private RoleManager<AppIdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "ELibrayAPI", Version = "v1" });
            });
            services.AddDbContext<ELibraryDBContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")));
            services.AddIdentity<ApplicationUser, AppIdentityRole>()
                .AddEntityFrameworkStores<ELibraryDBContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<IPublisher, EFPublisher>();
            services.AddTransient<IAppFile, EFAppFile>();
            services.AddTransient<IBooks, EFBook>();
            services.AddTransient<ITag, EFTag>();
            services.AddTransient<ICategory, EFCategory>();
            services.AddTransient<IAuthor, EFAuthor>();
            services.AddTransient<IType, EFType>();
            services.AddTransient<IMongoTagCategoryAssigment, MongoCategoryTagAssigments>();

            //services.AddAuthentication().AddFacebook(facebookOptions =>
            //{
            //    facebookOptions.AppId = ConfigurationManager.Instance.GetValue("FacebookAppId");
            //    facebookOptions.AppSecret = ConfigurationManager.Instance.GetValue("FacebookAppSecret");
            //});

            services.AddAutoMapper();
            DIManager.Instance.Builder.Populate(services);
            DIManager.Instance.Builder.RegisterType<SecurityContext>();
            DIManager.Instance.Build();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}
            //else
            //{
            //    app.UseHsts();
            //}

            app.UseDeveloperExceptionPage();

            app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials());

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action}/{id?}");
            });
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ELibrayAPI V1");
            });

            //CreateRolesandUsers();
        }
   
        private void CreateRolesandUsers()
        {
            _roleManager = DIManager.Instance.Provider.GetService<RoleManager<AppIdentityRole>>();
            _userManager = DIManager.Instance.Provider.GetService<UserManager<ApplicationUser>>();

            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!_roleManager.RoleExistsAsync("SUPERADMIN").Result)
            {
                // first we create Admin rool   
                var role = new AppIdentityRole();
                role.Name = "SUPERADMIN";
                _roleManager.CreateAsync(role);

                //Here we create a Admin super user who will maintain the website                  
            }
            if (_userManager.Users.FirstOrDefault(x => x.Email == "admin@mail.com") == null)
            {
                var user = new ApplicationUser();
                user.UserName = "superadmin";
                user.Email = "admin@mail.com";
                user.Gender = 1;

                string userPWD = "Elibrary1!";

                var chkUser = _userManager.CreateAsync(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Result.Succeeded)
                {
                    var result1 = _userManager.AddToRoleAsync(user, "SuperAdmin");
                }
            }
        }
    }
}
