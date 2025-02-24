using AECMVCProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AECMVCProject.Controllers
{
    public class BindController : Controller
    {
        //Primitive Type (int ,float ,string ...)

        //Bind/TestPrimitive?name=Ahmed&age=20&id=90
        //Bind/TestPrimitive/90?name=Ahmed&age=20&color[0]=red&color[1]=blue
        public IActionResult TestPrimitive(string name,int age,int id,string[] color)
        {
            return Content($"{name}\t{age}");
        }

        //Test Collection list 
        //Bind/TestDic?name=Christen&PhoneBook[Ahemd]=123&PhoneBook[mohamed]=456
        public IActionResult TestDic(Dictionary<string,string> PhoneBook,string name)
        {
            return Content("----");
        }

        //Complex Type
        //Bind/TestObj?id=1&name=SD&ManagerName=ahmed&Employees[0].NAme=Alaa

        public IActionResult TestObj(Department xyz)
        //public IActionResult TestObj(int Id, string Name, string? ManagerName, List<Employee>? Employees)
        {
            return Content("----");
        }

    }
}
