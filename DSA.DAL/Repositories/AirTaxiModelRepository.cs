using System.Collections.Generic;
using System.Linq;
using SAT.DAL.Context;
using SAT.DAL.Repositories.Contract;
using Microsoft.EntityFrameworkCore;
using SAT.Domain.AirTaxies;
using SAT.Domain.Params;
using LinqKit;

namespace SAT.DAL.Repositories
{
    public class AirTaxiModelRepository : Repository<AirTaxiModel>, IAirTaxiModelRepository
    {
        private readonly AirTaxiSharingContext _dbContext;

        public AirTaxiModelRepository(AirTaxiSharingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IEnumerable<AirTaxiModel> GetAirTaxiModels(string model)
        {
            return _dbContext.AirTaxiModels
                .Include(t => t.Company)
                .Include(t => t.Type)
                .Where(t => t.Name.Contains(model)).ToList();
        }

        public CollectionResult<AirTaxiModel> GetTaxiModelsByParams(TaxiModelFilterParams parameters)
        {
            var taxiModels = GetAllTaxiModels();

            FillAirTaxiModelQueryParams(parameters);

            taxiModels = taxiModels.Where(parameters.Expression);

            var totalCount = taxiModels.Count();

            var result = taxiModels
                .OrderBy(x => x.Name)
                .Skip(parameters.Skip)
                .Take(parameters.Take)
                .AsNoTracking()
                .ToList();

            var modelsResult = new CollectionResult<AirTaxiModel>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return modelsResult;
        }

        private IQueryable<AirTaxiModel> GetAllTaxiModels()
        {
            return _dbContext.AirTaxiModels
                .Include(t => t.Company)
                .Include(t => t.Type)
                .AsQueryable();
        }

        private void FillAirTaxiModelQueryParams(TaxiModelFilterParams filterParams)
        {
            var predicate = PredicateBuilder.True<AirTaxiModel>();

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                predicate = predicate.Extend(t => t.Name.Contains(filterParams.Term));
            }

            filterParams.Expression = predicate;
        }
    }
}
