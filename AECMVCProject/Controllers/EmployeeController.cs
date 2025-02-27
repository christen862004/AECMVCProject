using AECMVCProject.Models;
using AECMVCProject.Repository;
using AECMVCProject.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace AECMVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        //AECContext context = new AECContext();//tigh couple with AECContext
        //Implement DIP
        IEmployeeRepository EmployeeRepository;//lossly couple
        IDepartmentRepository DepartmentRepository;
        //Dependance Inject
        public EmployeeController(IEmployeeRepository EmpRepo, IDepartmentRepository DeptRepo)
        {
            EmployeeRepository = EmpRepo;
            DepartmentRepository = DeptRepo;
        }




        public IActionResult Index()
        {
            List<Employee> EmpsModel =EmployeeRepository.GetAll();
            return View("Index", EmpsModel);
        }
      
        public IActionResult CheckSalary(int Salary,string Address)
         {
            if (Address == "Alex")
            {
                if (Salary % 5 == 0)
                    return Json(true);
                else
                    return Json(false);
            }else if(Address == "Cairo")
            {
                if (Salary % 3 == 0)
                    return Json(true);
                else
                    return Json(false);
            }
            return Json(true);
        }

        #region New
        public IActionResult New()
        {
            ViewBag.deptList = DepartmentRepository.GetAll();//list<Department>
            return View("New");
        }
        //handel any request (internal | External )
        [HttpPost] //chec Request.MEthod="Post"
        [ValidateAntiForgeryToken] //Request.Form["_RequestVerificationToken"] Valid login
        public IActionResult SaveNew(Employee empFromRequest)
        {
            if(ModelState.IsValid==true)
            {
                try
                {
                    EmployeeRepository.Insert(empFromRequest);
                    EmployeeRepository.Save();
                    return RedirectToAction("Index");
                }catch(Exception ex)
                {
                    //local hsndel exception
                    //ModelState.AddModelError("DepartmentID","Select DEpt");//div

                    ModelState.AddModelError(string.Empty,ex.InnerException.Message);//div
                }
            }
            ViewBag.deptList = DepartmentRepository.GetAll();//list<Department>
            return View("New",empFromRequest);
        }
        #endregion

        #region Overload Employee/MEthod
        [HttpGet]
        public IActionResult Method()
        {
            return Content("Method1");
        }
        [HttpPost]
        public IActionResult Method(int id)
        {
            return Content("Method2");
        }
        #endregion

        #region Edit Actions
        public IActionResult Edit(int id)
        {
            Employee empModel = EmployeeRepository.GetById(id);
            if(empModel != null) {
                List<Department> deptList = DepartmentRepository.GetAll();
                EmployeeWithDeptListViewModel empVM = new ();
                //mapping
                empVM.Id = empModel.Id;
                empVM.Name = empModel.Name;
                empVM.Salary = empModel.Salary;
                empVM.JobTitle = empModel.JobTitle;
                empVM.ImageURL = empModel.ImageURL;
                empVM.Address = empModel.Address;
                empVM.DepartmentID = empModel.DepartmentID;
                empVM.DeptList = deptList;

                return View("Edit",empVM);//view Edit,Model Type EmpWithDeptlistViewModel
            }
            return NotFound();
        }


        [HttpPost]
        public IActionResult SaveEdit(EmployeeWithDeptListViewModel EmpFromRequest) {
            if(EmpFromRequest.Name != null) {
                //get old ref from context
                Employee empFromDB=EmployeeRepository.GetById(EmpFromRequest.Id);
                //change propert with new value
                empFromDB.Name= EmpFromRequest.Name;
                empFromDB.Salary= EmpFromRequest.Salary;
                empFromDB.Address= EmpFromRequest.Address;
                empFromDB.JobTitle= EmpFromRequest.JobTitle;
                empFromDB.ImageURL= EmpFromRequest.ImageURL;
                empFromDB.DepartmentID= EmpFromRequest.DepartmentID;
                //Save change
                EmployeeRepository.Save();
                return RedirectToAction("Index");
            }
          
            EmpFromRequest.DeptList = DepartmentRepository.GetAll();//refill detlist
            return View("Edit", EmpFromRequest);
        }

        #endregion


        #region Details

        public IActionResult Details(int id)
        {
            //collection ,object
            string msg = "Welcomee";
            int Temp = 10;
            string Color = "Red";
            List<string> Faculities = new List<string>() 
            { "Engineer","FCI","Agrucatiure","Law"};
            //----full ViewData
            ViewData["Msg"] = msg;
            ViewData["Temp"] = 10;
            ViewData["Clr"] = Color;
            ViewData["Faculty"] = Faculities;
            ViewBag.Age = 10;
            ViewBag.Clr = "blue";
            //-----------------------------------

            Employee EmpModel=
                EmployeeRepository.GetById(id);
           
            return View("Details", EmpModel);//View DEtails ,Model With type Employeee
        }


        public IActionResult DetailsVM(int id)
        {
            //logic
            string msg = "Welcomee";
            int Temp = 10;
            string Color = "Red";
            List<string> Faculities = new List<string>()
            { "Engineer","FCI","Agrucatiure","Law"};
         
            Employee EmpModel =
                EmployeeRepository.GetById(id);
            //-----------------------------------
            //Declare ViewModel
            var EmpVM = new EmployeeWithTempMsgClrFacultyListViewModel();
            //set data  in ViewModel  (automapper)
            EmpVM.EmpId = EmpModel.Id;
            EmpVM.EmpName = EmpModel.Name;
            EmpVM.EmpImag = EmpModel.ImageURL;

            EmpVM.Faculities = Faculities;
            EmpVM.Message = msg;
            EmpVM.Temp = Temp;
            EmpVM.Color = "red";
            //send ViewModel ==>view



            return View("DetailsVM",EmpVM);

            //View DEtailsVM ,Model with type EmployeeWithTempMsgClrFacultyListViewModel
        }
        #endregion
    }
}
