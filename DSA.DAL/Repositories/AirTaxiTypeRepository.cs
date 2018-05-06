using System.Collections.Generic;
using System.Linq;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using SAT.DAL.Context;
using SAT.DAL.Repositories.Contract;
using SAT.Domain.AirTaxies;
using SAT.Domain.Params;

namespace SAT.DAL.Repositories
{
    public class AirTaxiTypeRepository : Repository<AirTaxiType>, IAirTaxiTypeRepository
    {
        private readonly AirTaxiSharingContext _dbContext;

        public AirTaxiTypeRepository(AirTaxiSharingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AirTaxiType> GetAirTaxiTypes(string type)
        {
            return _dbContext.AirTaxiTypes.Where(t => t.Name.Contains(type)).OrderBy(t => t.Name).ToList();
        }

        public CollectionResult<AirTaxiType> GetTaxiTypesByParams(TaxiTypesFilterParams parameters)
        {
            var airTaxiTypes = GetAllTypes();

            FillAirTaxiQueryParams(parameters);

            airTaxiTypes = airTaxiTypes.Where(parameters.Expression);

            var totalCount = airTaxiTypes.Count();

            var result = airTaxiTypes
                .OrderBy(t => t.Name)
                .Skip(parameters.Skip)
                .Take(parameters.Take)
                .AsNoTracking()
                .ToList();

            var typesResult = new CollectionResult<AirTaxiType>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return typesResult;
        }

        private IQueryable<AirTaxiType> GetAllTypes()
        {
            return _dbContext.AirTaxiTypes.AsQueryable();
        }

        private void FillAirTaxiQueryParams(TaxiTypesFilterParams filterParams)
        {
            var predicate = PredicateBuilder.True<AirTaxiType>();

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                predicate = predicate.Extend(t => t.Name.Contains(filterParams.Term));
            }

            filterParams.Expression = predicate;
        }
    }
}
