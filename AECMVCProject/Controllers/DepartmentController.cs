using AECMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

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

        #region New DEpartment Actions

        public IActionResult New()
        {
            return View("New");//model null
        }
        ///Department/SaveNew?Name= & ManagerName= <summary>
        /// by ddefault mvc action can handel GEt REuest or Post Request

        [HttpPost]
        public IActionResult SaveNEw(Department newDeptFromRequest)
        {
            //if (Request.Method == "POST")
            
            if (newDeptFromRequest.Name != null)
            {
                Context.Department.Add(newDeptFromRequest);
                Context.SaveChanges();
                return RedirectToAction("Index");//, "Department", new {id=1,name=2});
            }
            return View("New", newDeptFromRequest);//view new ,model Department
            

        }
        #endregion
    }
}
