using AECMVCProject.Models;
using AECMVCProject.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace AECMVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        AECContext context = new AECContext();

        public IActionResult Index()
        {
            List<Employee> EmpsModel = context.Employee.ToList();
            return View("Index", EmpsModel);
        }

        #region New
        public IActionResult New()
        {
            ViewBag.deptList = context.Department.ToList();//list<Department>
            return View("New");
        }
        //handel any request (internal | External )
        [HttpPost] //chec Request.MEthod="Post"
        [ValidateAntiForgeryToken] //Request.Form["_RequestVerificationToken"] Valid login
        public IActionResult SaveNew(Employee empFromRequest)
        {
            if(empFromRequest.Name!=null && empFromRequest.Salary > 6000)
            {
                //mapping from viewModel to Model Employee
                context.Add(empFromRequest);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.deptList = context.Department.ToList();//list<Department>
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
            Employee empModel=context.Employee.FirstOrDefault(x => x.Id == id);
            if(empModel != null) {
                List<Department> deptList = context.Department.ToList();
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
                Employee empFromDB=context.Employee.FirstOrDefault(e=>e.Id== EmpFromRequest.Id);
                //change propert with new value
                empFromDB.Name= EmpFromRequest.Name;
                empFromDB.Salary= EmpFromRequest.Salary;
                empFromDB.Address= EmpFromRequest.Address;
                empFromDB.JobTitle= EmpFromRequest.JobTitle;
                empFromDB.ImageURL= EmpFromRequest.ImageURL;
                empFromDB.DepartmentID= EmpFromRequest.DepartmentID;
                //Save change
                context.SaveChanges();
                return RedirectToAction("Index");
            }
          
            EmpFromRequest.DeptList = context.Department.ToList();//refill detlist
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
                context.Employee.FirstOrDefault(e=>e.Id == id);
           
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
                context.Employee.FirstOrDefault(e => e.Id == id);
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
