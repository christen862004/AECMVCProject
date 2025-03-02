using AECMVCProject.Models;

namespace AECMVCProject.Repository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        //Simple DEmo
        List<Employee> GetByDeptID(int deptID);
    }
}