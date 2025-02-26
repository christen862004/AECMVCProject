using System.ComponentModel.DataAnnotations;

namespace AECMVCProject.Models
{
    //C# ==> Server Side
    public class UniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
            string name = value.ToString();

            Employee EmpFRomREquest=validationContext.ObjectInstance as Employee;

            AECContext context = new AECContext();
            Employee EmpFromDataBase= 
                context.Employee.FirstOrDefault(e => e.Name == name && e.DepartmentID ==EmpFRomREquest.DepartmentID);
           
            if(EmpFromDataBase == null)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("this Name already Exist");
            }
        }
    }
}
