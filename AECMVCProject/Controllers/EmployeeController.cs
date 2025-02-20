using AECMVCProject.Models;
using AECMVCProject.ViewModel;
using Microsoft.AspNetCore.Mvc;


namespace AECMVCProject.Controllers
{
    public class EmployeeController : Controller
    {
        AECContext context = new AECContext();
        public EmployeeController()
        {
            
        }
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
    }
}
