using DSA.DAL.Repositories.Contract;

namespace DSA.DAL.UnitOfWork.Contract
{
    public interface IDronSharingUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; set; }

        IDronRepository DronRepository { get; set; }

        IDronModelRepository DronModelRepository { get; set; }

        IDronCompanyRepository DronCompanyRepository { get; set; }

        IDronTypeRepository DronTypeRepository { get; set; }

        IRentRepository RentRepository { get; set; }

        void Commit();
    }
}
