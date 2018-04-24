using System.Linq;
using DSA.DAL.Context;
using DSA.DAL.Repositories.Contract;
using Microsoft.EntityFrameworkCore;

namespace DSA.DAL.Repositories
{
    public class DronSharingRepository<T> : IDronSharingRepository<T> where T : class
    {
        public DronSharingRepository(DronSharingContext dbContext)
        {
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
        }

        protected DronSharingContext DbContext { get; set; }

        protected DbSet<T> DbSet { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return DbSet;
        }

        public virtual T GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Update(T entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = GetById(id);

            if (entity == null)
            {
                return;
            }

            DbSet.Remove(entity);
        }
    }
}
