using AECMVCProject.Models;

namespace AECMVCProject.Repository
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        
        T GetById(int id);
        
        void Insert(T obj);
        
        void Update(T obj);
        
        void Delete(int id);
        
        int Save();
    }
}