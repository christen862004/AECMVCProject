using System.ComponentModel.DataAnnotations;

namespace AECMVCProject.Models
{
    public class Department
    {
        public int Id { get; set; } //pk + idenitiy 1,1
        public string Name { get; set; } //Not Allow Null
        public string? ManagerName { get; set; }//Allow Null

        public List<Employee>? Employees { get; set; }//naviggation

    }
}
