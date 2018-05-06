using System.Linq;
using SAT.DAL.Context;
using SAT.DAL.Repositories.Contract;
using SAT.Domain.Params;
using SAT.Domain.Rents;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace SAT.DAL.Repositories
{
    public class RentRepository : Repository<Rent>, IRentRepository
    {
        private readonly AirTaxiSharingContext _dbContext;

        public RentRepository(AirTaxiSharingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public CollectionResult<Rent> GetRentsByParams(RentsFilterParams filterParams)
        {
            var rents = GetAllRents();

            FillRentQueryParams(filterParams);

            rents = rents.Where(filterParams.Expression);

            var totalCount = rents.Count();

            var result = rents
                .Skip(filterParams.Skip)
                .Take(filterParams.Take)
                .AsNoTracking()
                .ToList();

            var rentResult = new CollectionResult<Rent>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return rentResult;
        }

        private IQueryable<Rent> GetAllRents()
        {
            return _dbContext.Rents
                .Include(t => t.AirTaxi)
                .Include(t => t.AirTaxi).ThenInclude(t => t.AirTaxiModel)
                .Include(t => t.AirTaxi).ThenInclude(t => t.AirTaxiModel).ThenInclude(t => t.Company)
                .Include(t => t.AirTaxi).ThenInclude(t => t.AirTaxiModel).ThenInclude(t => t.Type)
                .Include(t => t.Customer)
                .AsQueryable();
        }

        private void FillRentQueryParams(RentsFilterParams filterParams)
        {
            var predicate = PredicateBuilder.True<Rent>();

            if (!string.IsNullOrEmpty(filterParams.CustomerId))
            {
                predicate = predicate.Extend(t => t.CustomerId == filterParams.CustomerId);
            }

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                predicate = predicate.Extend(t => t.AirTaxi.AirTaxiModel.Name.Contains(filterParams.Term));
            }

            if (filterParams.AirTaxiModelId.HasValue)
            {
                predicate = predicate.Extend(t => t.AirTaxi.AirTaxiModelId == filterParams.AirTaxiModelId.Value);
            }

            filterParams.Expression = predicate;
        }
    }
}
