using Microsoft.AspNetCore.Mvc;

namespace AECMVCProject.Controllers
{
    public class RouteController : Controller
    {
       
        //m1/ahmed/12
        //m1/christen/1233
        [Route("r/{name}/{age:int:range(20,40)}/{id?}")]
        public IActionResult MEthod1(string name,int age)
        {
            return Content("MEthod1 Route Controller");
        }

        //Route/MEthod2
        //m2
        public IActionResult MEthod2()
        {
            return Content("MEthod2 Route Controller");
        }
    }
}
