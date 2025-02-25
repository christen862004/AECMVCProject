using Microsoft.AspNetCore.Builder;

namespace AECMVCProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container. Day8
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(
                option => {
                    option.IdleTimeout = TimeSpan.FromMinutes(30);
                });//default seetin session Meddleware

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
