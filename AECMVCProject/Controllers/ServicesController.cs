using AECMVCProject.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AECMVCProject.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IDepartmentRepository deptRepo;

        public ServicesController(IDepartmentRepository deptRepo)//injection constructor
        {
            this.deptRepo = deptRepo;
        }
        public IActionResult Index()//[FromServices]IDepartmentRepository deptRepo)
        {
            ViewData["ID"] = deptRepo.ID;
            return View();
        }
    }
}
