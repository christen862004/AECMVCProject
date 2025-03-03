using AECMVCProject.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace AECMVCProject.Controllers
{
    [HandelError]
   // [Authorize]
    public class FilterController : Controller
    {
        [Authorize(Roles ="Admin")]//cookie==>login
        public IActionResult TestAuth()
        {
            //if (User.IsInRole("Admin")) { }
            Claim idClaim = User.Claims.FirstOrDefault(c => c.Type ==ClaimTypes.NameIdentifier);
            string id = idClaim.Value;

            Claim addressClaim = User.Claims.FirstOrDefault(c => c.Type == "Address");

            return Content($"Welcome Ya {User.Identity.Name} \t Address ={addressClaim.Value}");


            //if (User.Identity.IsAuthenticated == true)
            //{
            //    return Content($"Welcome Ya {User.Identity.Name}");
            //}
            ////User==>Cookie
            //return Content("Welcome Ya Gust");
        }


        //[HandelError]//Filter action exception
     //   [AllowAnonymous]
      //  [HttpPost]
        public IActionResult Index()
        {
            
            //some code throw exception
            throw new Exception("Some Exception throw");
            return View();
        }

        //[HandelError]
        public IActionResult Index2()
        {
            //some code throw exception
            throw new Exception("Some Exception throw");
            return View();
        }
    }
}
