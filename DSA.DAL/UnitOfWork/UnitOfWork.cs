using System;
using SAT.DAL.Context;
using SAT.DAL.Repositories.Contract;
using SAT.DAL.UnitOfWork.Contract;

namespace SAT.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AirTaxiSharingContext _context;

        public UnitOfWork(AirTaxiSharingContext context)
        {
            _context = context;
        }

        public ICustomerRepository CustomerRepository { get; set; }

        public IAirTaxiRepository AirTaxiRepository { get; set; }

        public IAirTaxiModelRepository AirTaxiModelRepository { get; set; }

        public IAirTaxiCompanyRepository AirTaxiCompanyRepository { get; set; }

        public IAirTaxiTypeRepository AirTaxiTypeRepository { get; set; }

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
