using System.Linq;

namespace DSA.DAL.Repositories.Contract
{
    public interface IDronSharingRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
