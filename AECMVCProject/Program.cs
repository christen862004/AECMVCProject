using AECMVCProject.Filters;
using AECMVCProject.Models;
using AECMVCProject.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AECMVCProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the IOC container(ServiceProvider). Day8
            //Built In Service
            //1 ) built in services  ,already register
            //2 ) built in services  ,need to register 
            builder.Services.AddControllersWithViews();
            //options =>{
            //    //global filter
            //    options.Filters.Add(new HandelErrorAttribute());
            //});
            builder.Services.AddSession(
                option => {
                    option.IdleTimeout = TimeSpan.FromMinutes(30);
                });
            builder.Services.AddDbContext<AECContext>(
                options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("cs"));
                });
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options=>
            {//Yara
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = true;
            }).AddEntityFrameworkStores<AECContext>();














            //Custom Service : decalre ,need to register
            builder.Services.AddScoped<IEmployeeRepository,EmployeeRepository>();
            builder.Services.AddScoped<IDepartmentRepository,DepartmentRepository>();


            var app = builder.Build();

            #region Custom (inline) Middleware

            //app.Use(async (httpContext, next) =>
            //{
            //    //if(httpContext.Request.)
            //    await httpContext.Response.WriteAsync("1- Middleware \n");
            //    await next.Invoke();
            //    await httpContext.Response.WriteAsync("1-1 Middleware \n");

            //});
            //app.Use(async (httpContext, next) =>
            //{
            //    await httpContext.Response.WriteAsync("2- Middleware \n");
            //    await next.Invoke();
            //    await httpContext.Response.WriteAsync("2-2 Middleware \n");

            //});

            //app.Run(async (httpContext) =>
            //{
            //    await httpContext.Response.WriteAsync("3- Terminate \n");
            //});


            #endregion


            #region Built In Middlwares
            // Configure the HTTP request pipeline.Day3 Middelwares
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();//css/sity.css 

            app.UseRouting(); //Department/All  (Mapping) (Security)

            app.UseSession();

            app.UseAuthorization();//role form remember

            //DEcalre Route Template + Execute
            //app.MapControllerRoute(
            //  name: "Route1",
            //  pattern: "M1/{name:alpha}/{age:int:range(20,40)}",//m1/ahmed   m1/ahmed/12
            //  defaults: new{ controller="Route", action="Method1"});

            //app.MapControllerRoute(
            //  name: "Route1",
            //  pattern: "{contorller}/{action}",
            //  defaults: new { controller = "Route", action = "Method2" });


            //app.MapControllerRoute(
            //name: "Route2",
            //pattern: "M2",
            //defaults: new { controller = "Route", action = "Method2" });
            //DEfault Micrsoft
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion
            app.Run();
        }
    }
}
