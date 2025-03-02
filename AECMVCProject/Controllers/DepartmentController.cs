using AECMVCProject.Models;
using AECMVCProject.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace AECMVCProject.Controllers
{
    public class DepartmentController : Controller
    {
        // AECContext Context = new AECContext();DIP
        IDepartmentRepository DeptRepository;
        private readonly IEmployeeRepository empRepo;

        public DepartmentController
            (IDepartmentRepository deptReop,IEmployeeRepository EmpRepo)
        {
            DeptRepository = deptReop;
            empRepo = EmpRepo;
        }

        
        public IActionResult Index()
        {
            List<Department> DEptListModel=
                DeptRepository.GetAll();
            return View("Index",DEptListModel);//View Index ,Model With type List<department>
        }

        #region Return PartialView
        
        public IActionResult ShowDeptEmployees()
        {
            List<Department> DeptList= DeptRepository.GetAll();
            return View("ShowDeptEmployees", DeptList);

        }

        
        //Department/EmpsByDEptId?deptId=1 

        public IActionResult EmpsByDEptId(int deptId)
        {
            List<Employee> EmpList= empRepo.GetByDeptID(deptId);
            return Json(EmpList);
        }

        public IActionResult DetailPartial(int id) {
            Department deptModel = DeptRepository.GetById(id);
           // return PartialView("_DeptCard", deptModel);
           return Json(deptModel);
        }
        #endregion


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

        #region Details  Delete
        public IActionResult Details(int id)
        {
            Department deptModel = DeptRepository.GetById(id);
            return View("Details", deptModel);
        }
        public IActionResult Delete(int id)
        {
            Department deptModel = DeptRepository.GetById(id);
            return View("Delete", deptModel);
        }
        #endregion
    }
}
