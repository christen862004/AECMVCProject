using AECMVCProject.Models;

namespace AECMVCProject.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        AECContext context;

        public string ID{ get; set; }

        public DepartmentRepository(AECContext _context)
        {
            ID = Guid.NewGuid().ToString();
            context = _context;
        }
        //CRUD
        public List<Department> GetAll()
        {
            return context.Department.ToList();
        }
        public Department GetById(int id)
        {
            return context.Department.FirstOrDefault(d=>d.Id==id);
        }
        public void Insert(Department obj)
        {
            context.Add(obj);
        }
        public void Update(Department obj)
        {
            context.Update(obj);
        }
        public void Delete(int id)
        {
            Department dept = GetById(id);
            context.Remove(dept);
        }
        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
