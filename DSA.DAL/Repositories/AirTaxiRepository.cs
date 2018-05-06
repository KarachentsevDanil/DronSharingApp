using System.Linq;
using SAT.DAL.Context;
using SAT.DAL.Repositories.Contract;
using SAT.Domain.Params;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using SAT.Domain.AirTaxies;

namespace SAT.DAL.Repositories
{
    public class AirTaxiRepository : Repository<AirTaxi>, IAirTaxiRepository
    {
        private readonly AirTaxiSharingContext _dbContext;

        public AirTaxiRepository(AirTaxiSharingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        private IQueryable<AirTaxi> GetAllAirTaxies()
        {
            return _dbContext.AirTaxi
                .Include(t => t.AirTaxiModel)
                .Include(t => t.AirTaxiModel).ThenInclude(t => t.Company)
                .Include(t => t.AirTaxiModel).ThenInclude(t => t.Type)
                .Include(t => t.Customer)
                .AsQueryable();
        }

        private void FillAirTaxiQueryParams(TaxiesFilterParams filterParams)
        {
            var predicate = PredicateBuilder.True<AirTaxi>();

            if (!string.IsNullOrEmpty(filterParams.CustomerId))
            {
                predicate = predicate.Extend(t => t.CustomerId == filterParams.CustomerId);
            }

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                predicate = predicate.Extend(t => t.AirTaxiModel.Name.Contains(filterParams.Term));
            }

            if (filterParams.AirTaxiModelId.HasValue)
            {
                predicate = predicate.Extend(t => t.AirTaxiModelId == filterParams.AirTaxiModelId.Value);
            }

            if (filterParams.AirTaxiCompanyId.HasValue)
            {
                predicate = predicate.Extend(t => t.AirTaxiModel.AirTaxiCompanyId == filterParams.AirTaxiCompanyId.Value);
            }

            if (filterParams.AirTaxiTypeId.HasValue)
            {
                predicate = predicate.Extend(t => t.AirTaxiModel.AirTaxiTypeId == filterParams.AirTaxiTypeId.Value);
            }

            filterParams.Expression = predicate;
        }

        public CollectionResult<AirTaxi> GetAirTaxiesByParams(TaxiesFilterParams filterParams)
        {
            var airTaxies = GetAllAirTaxies();

            FillAirTaxiQueryParams(filterParams);

            airTaxies = airTaxies.Where(filterParams.Expression);

            var totalCount = airTaxies.Count();

            var result = airTaxies
                .Skip(filterParams.Skip)
                .Take(filterParams.Take)
                .AsNoTracking()
                .ToList();

            var airTaxiResult = new CollectionResult<AirTaxi>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return airTaxiResult;
        }
    }
}
