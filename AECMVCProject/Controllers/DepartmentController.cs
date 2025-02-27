using AECMVCProject.Models;
using AECMVCProject.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace AECMVCProject.Controllers
{
    public class DepartmentController : Controller
    {
        // AECContext Context = new AECContext();
        IDepartmentRepository DeptRepository;
        public DepartmentController(IDepartmentRepository deptReop)
        {
            DeptRepository = deptReop;
        }
        public IActionResult Index()
        {
            List<Department> DEptListModel=
                DeptRepository.GetAll();
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
                DeptRepository.Insert(newDeptFromRequest);
                DeptRepository.Save();
                return RedirectToAction("Index");//, "Department", new {id=1,name=2});
            }
            return View("New", newDeptFromRequest);//view new ,model Department
            

        }
        #endregion
    }
}
