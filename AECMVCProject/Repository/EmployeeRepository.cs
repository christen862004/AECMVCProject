using AECMVCProject.Models;

namespace AECMVCProject.Repository
{
    public class EmployeeRepository: IEmployeeRepository
    {
        //CRUD
        AECContext context;
        public EmployeeRepository(AECContext _context)
        {
            context =_context;// new AECContext();
        }
        //CRUD
        public List<Employee> GetAll()
        {
            return context.Employee.ToList();
        }
        public Employee GetById(int id)
        {
            return context.Employee.FirstOrDefault(e => e.Id == id);
        }
        public void Insert(Employee obj)
        {
            context.Add(obj);
        }
        public void Update(Employee obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Employee emp = GetById(id);
            context.Remove(emp);
        }
        public int Save()
        {
            return context.SaveChanges();
        }

        public List<Employee> GetByDeptID(int deptID)
        {
            return context.Employee.Where(e=>e.DepartmentID==deptID).ToList();  
        }
    }
}
