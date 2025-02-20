using AECMVCProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AECMVCProject.Controllers
{
    public class DepartmentController : Controller
    {
        AECContext Context = new AECContext();
        public IActionResult Index()
        {
            List<Department> DEptListModel=
                Context.Department.ToList();
            return View("Index",DEptListModel);//View Index ,Model With type List<department>
        }
    }
}
