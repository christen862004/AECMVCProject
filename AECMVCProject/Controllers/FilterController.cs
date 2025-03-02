using AECMVCProject.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Runtime.InteropServices;

namespace AECMVCProject.Controllers
{
    [HandelError]
   // [Authorize]
    public class FilterController : Controller
    {
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
