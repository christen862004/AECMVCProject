using AECMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AECMVCProject.Controllers
{
    public class HomeController : Controller 
    {
        //MEthod Called ==>Actions
        /// Method must be public 
        /// Method Cant be Static
        /// Method Cant Be Overload (only in one Case)
        
        
        //Endpoint: /home/ShowMsg
        public ContentResult ShowMsg()
        {
            //declare
            ContentResult result = new ContentResult();
            //fill
            result.Content = "Hello From My First MEthod inside Contoller";
            //return 
            return result;
        }

        //Home/ShowView
        public ViewResult ShowView()
        {
            //logic.......
            //decalre
            ViewResult result = new ViewResult();
            //fill
            result.ViewName = "View1";
            //return
            return result;
        }

        //action tae parameter odd (content) | even (View)
        //Home/ShowMix?no=5&id=90 [Query String]
        //Home/ShowMix/90?no=5
        public IActionResult ShowMix(int no)//,int id)
        {
            if (no % 2 == 0)
            {
                //logic
                return View("View1");
            }
            else
            {
                return Content("My second action");
            }
        }

        //dry : dont repeat yourself
        //home/view?viewname=View1
        //[NonAction]//no endpoint
        //public ViewResult View(string ViewName)
        //{
        //    ViewResult result = new ViewResult();
        //    //fill
        //    result.ViewName = ViewName;
        //                              //return
        //    return result;
        //}












        //Any Action can resturn
        /// <summary>
        /// ActionResult==>IActionResult
        /// Content   ==> ContentResult
        /// View      ==> ViewResult
        /// Json      ==> JsonREsult
        /// Empty     ==> EmptyResult
        /// NotFound  ==> NotFoundResult
        /// File     ...
        /// ......
        /// </summary>









        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
