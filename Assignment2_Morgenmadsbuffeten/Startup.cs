//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.HttpsPolicy;
//using Microsoft.EntityFrameworkCore;
//using Assignment2_Morgenmadsbuffeten.Data;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Assignment2_Morgenmadsbuffeten.Data.Migrations;
//using Microsoft.Extensions.Logging;
//using Assignment2_Morgenmadsbuffeten.Models;
//using Microsoft.AspNetCore.Http;

//namespace Assignment2_Morgenmadsbuffeten
//{
//    public class Startup
//    {
//        public Startup(IConfiguration configuration)
//        {
//            Configuration = configuration;
//        }

//        public IConfiguration Configuration { get; }

//        // This method gets called by the runtime. Use this method to add services to the container.
//        public void ConfigureServices(IServiceCollection services)
//        {
//            services.Configure<CookiePolicyOptions>(options =>
//            {
//                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
//                options.CheckConsentNeeded = context => true;
//                options.MinimumSameSitePolicy = SameSiteMode.None;
//            });
//            services.AddDbContext<ApplicationDbContext>(options =>
//                options.UseSqlServer(
//                    Configuration.GetConnectionString("DefaultConnection")));
//            services.AddDefaultIdentity<ApplicationUser>()
//                .AddEntityFrameworkStores<ApplicationDbContext>();

//            services.AddAuthorization(options =>
//            {
//                options.AddPolicy(
//                    "IsReceptionist",
//                    policyBuilder => policyBuilder
//                     .RequireClaim("Reception"));
//            });

//            services.AddControllersWithViews();
//            services.AddRazorPages();

//            //services.AddMvc();
//        }

//        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager, ApplicationDbContext context,
//            ILogger<Startup> log)
//        {
//            if (env.IsDevelopment())
//            {
//                app.UseDeveloperExceptionPage();
//                app.UseDatabaseErrorPage();
//            }
//            else
//            {
//                app.UseExceptionHandler("/Home/Error");
//                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//                app.UseHsts();
//            }
//            app.UseHttpsRedirection();
//            app.UseStaticFiles(new StaticFileOptions()
//            {
//                OnPrepareResponse = ctx =>
//                {
//                    ctx.Context.Response.Headers.Append("Cache-Control",
//                        "public,max-age=2419200");
//                }
//            });

//            app.UseRouting();
//            app.UseCookiePolicy();
//            app.UseAuthentication();

//           // DbHelper.SeedData(context, userManager, log);
//            app.UseAuthorization();

//            //app.UseMvc(routes =>
//            //{
//            //    routes.MapRoute(
//            //        name: "default",
//            //        template: "{controller=Home}/{action=Index}/{id?}");
//            //});

//            app.UseEndpoints(endpoints =>
//            {
//                endpoints.MapControllers();
//                endpoints.MapRazorPages();

//            });
//        }
//    }
//}
using Assignment2_Morgenmadsbuffeten.Data;
using Assignment2_Morgenmadsbuffeten.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Assignment2_Morgenmadsbuffeten
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<ApplicationUser> userManager, ApplicationDbContext context, ILogger<Startup> log)
        //{ 
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext context, ILogger<Startup> log)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}

