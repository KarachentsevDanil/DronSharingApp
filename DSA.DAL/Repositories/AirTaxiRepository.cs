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
                predicate = predicate.And(t => t.CustomerId == filterParams.CustomerId);
            }

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                predicate = predicate.And(t => t.AirTaxiModel.Name.Contains(filterParams.Term));
            }

            if (filterParams.SelectedTypeIds != null && filterParams.SelectedTypeIds.Any())
            {
                predicate = predicate.And(t => filterParams.SelectedTypeIds.Any(id => id == t.AirTaxiModel.AirTaxiTypeId));
            }

            if (filterParams.SelectedCompanyIds != null && filterParams.SelectedCompanyIds.Any())
            {
                predicate = predicate.And(t => filterParams.SelectedCompanyIds.Any(id => id == t.AirTaxiModel.AirTaxiCompanyId));
            }

            if (filterParams.SelectedModelIds != null && filterParams.SelectedModelIds.Any())
            {
                predicate = predicate.And(t => filterParams.SelectedModelIds.Any(id => id == t.AirTaxiModelId));
            }

            if (filterParams.Start.HasValue && filterParams.End.HasValue)
            {
                predicate = predicate.And(t => !t.Rents.Any() || !(t.Rents.Any(r => filterParams.Start.Value <= r.EndDate && filterParams.End.Value >= r.StartDate)));
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

        public AirTaxi GetTaxiById(int id)
        {
            return GetAllAirTaxies().FirstOrDefault(t => t.AirTaxiId == id);
        }
    }
}
