using Microsoft.AspNetCore.Mvc;

namespace AECMVCProject.Controllers
{
    public class StateController : Controller
    {
        public IActionResult SetCookie()
        {
            //logic
            CookieOptions cookieOption = new CookieOptions();
            cookieOption.Expires=DateTimeOffset.Now.AddDays(1);
           
            
            //Session Cookie
            HttpContext.Response.Cookies.Append("Name", "Ahmed");
            //Presisitent Cookie (dead Line)
            HttpContext.Response.Cookies.Append("Color", "red", cookieOption);
            return Content("Cooie Save");
        }

        public IActionResult GetCookie()
        {
            //logic
        
            string name = HttpContext.Request.Cookies["Name"];
            
            string clr = HttpContext.Request.Cookies["Color"];

            return Content($"Cooie DAta {name} \t {clr}");
        }


        #region Session
        public IActionResult SetSession()
        {
            //logic 
            //Store StateManagment ==>serializorn to json
            string name = "Ahemd";
            int age = 20;
            HttpContext.Session.SetString("Name",name);//slide
            HttpContext.Session.SetInt32("Age",age);//slide
            return Content("Data Saved");
        }

        public IActionResult GetSession() {
            string n= HttpContext.Session.GetString("Name");
            int? a =  HttpContext.Session.GetInt32("Age");

            return Content($"name={n} \t age={a}");
        }

        #endregion
       
        #region TestState
        //int Counter;
        //public StateController()
        //{
        //    Counter = 0;
        //}
        //public IActionResult Increament()
        //{
        //    Counter++;
        //    return Content(Counter.ToString());
        //}
        #endregion
    }
}
