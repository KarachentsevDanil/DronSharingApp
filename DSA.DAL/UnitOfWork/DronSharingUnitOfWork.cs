using System;
using DSA.DAL.Context;
using DSA.DAL.Repositories.Contract;
using DSA.DAL.UnitOfWork.Contract;

namespace DSA.DAL.UnitOfWork
{
    public class DronSharingUnitOfWork : IDronSharingUnitOfWork, IDisposable
    {
        private readonly DronSharingContext _context;

        public DronSharingUnitOfWork(DronSharingContext context)
        {
            _context = context;
        }

        public ICustomerRepository CustomerRepository { get; set; }

        public IDronRepository DronRepository { get; set; }

        public IDronModelRepository DronModelRepository { get; set; }

        public IDronCompanyRepository DronCompanyRepository { get; set; }

        public IDronTypeRepository DronTypeRepository { get; set; }

        public IRentRepository RentRepository { get; set; }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
