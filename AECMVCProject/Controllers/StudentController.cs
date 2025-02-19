using AECMVCProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AECMVCProject.Controllers
{
    public class StudentController : Controller
    {
        StudentBL studentBL = new StudentBL();

        public IActionResult All()
        {
            //as kmodel
            List<Student> StudentsModel= studentBL.GetAll();
            //send data to view
            //return View("ShowAll");//empty withut any data
            return View("ShowAll",StudentsModel);//View = "Showall" ,Model wiht type List<student>
        }

        //endpoint Student/Details?id=1
        //endpoint Student/Details/1   [RouteValue]
        public IActionResult Details(int id)
        {
            Student StdModel= studentBL.GetByID(id);
            return View("Details",StdModel);//view Details, Model With type Student
        }
    }
}
