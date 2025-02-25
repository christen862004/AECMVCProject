using AECMVCProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AECMVCProject.ViewModel
{
    public class EmployeeWithDeptListViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name="Emp Address")]
        //[DataType(DataType.EmailAddress)]
        public string? Address { get; set; }
        public string? ImageURL { get; set; }
        public string? JobTitle { get; set; }
        public int Salary { get; set; }

        public int DepartmentID { get; set; }

        public List<Department> DeptList { get; set; }

    }
}
