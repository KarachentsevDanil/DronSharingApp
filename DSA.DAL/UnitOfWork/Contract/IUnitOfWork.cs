using SAT.DAL.Repositories.Contract;

namespace SAT.DAL.UnitOfWork.Contract
{
    public interface IUnitOfWork
    {
        ICustomerRepository CustomerRepository { get; set; }

        IAirTaxiRepository AirTaxiRepository { get; set; }

        IAirTaxiModelRepository AirTaxiModelRepository { get; set; }

        IAirTaxiCompanyRepository AirTaxiCompanyRepository { get; set; }

        IAirTaxiTypeRepository AirTaxiTypeRepository { get; set; }

        IRentRepository RentRepository { get; set; }

        void Commit();
    }
}
