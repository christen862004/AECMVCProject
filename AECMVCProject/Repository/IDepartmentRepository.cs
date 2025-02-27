using AECMVCProject.Models;

namespace AECMVCProject.Repository
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        //Extend DEpartment MEthod
        string ID { get; set; }
    }
}