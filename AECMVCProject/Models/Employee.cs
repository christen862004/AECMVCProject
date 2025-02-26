using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AECMVCProject.Models
{
    
    public class Employee
    {
        public int Id { get; set; }
        
        [Unique]
        [Required]
        [MinLength(3,ErrorMessage ="NAme Must Be more than  char")]
        [MaxLength(25,ErrorMessage ="Name Must be LEss Than 25 Char")]
        public string Name { get; set; }

        public string? Address { get; set; }

        [RegularExpression(@"\w+\.(jpg|png)",ErrorMessage ="Image Must be jpg or pnd")]
        public string? ImageURL { get; set; }

        public string? JobTitle { get; set; }
        
        [Remote("CheckSalary","Employee"
            ,ErrorMessage ="Salary not Valid",AdditionalFields = "Address")]
        [Range(6000,50000,ErrorMessage ="Salary must be between 6000 , 50000")]
        public int Salary { get; set; }

        [ForeignKey("Department")]
        [Display(Name="Department Name")]
        public int DepartmentID { get; set; }

        public Department? Department { get; set; }
    }
}
