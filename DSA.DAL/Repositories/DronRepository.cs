using System.Linq;
using DSA.DAL.Context;
using DSA.DAL.Repositories.Contract;
using DSA.Domain.Drons;
using DSA.Domain.Params;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace DSA.DAL.Repositories
{
    public class DronRepository : DronSharingRepository<Dron>, IDronRepository
    {
        private readonly DronSharingContext _dbContext;

        public DronRepository(DronSharingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public CollectionResult<Dron> GetDronsByParams(DronsFilterParams filterParams)
        {
            var drons = GetAllDrons();

            FillDronQueryParams(filterParams);

            drons = drons.Where(filterParams.Expression);

            var totalCount = drons.Count();

            var result = drons
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize == 0 ? int.MaxValue : filterParams.PageSize)
                .AsNoTracking()
                .ToList();

            var dronResult = new CollectionResult<Dron>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return dronResult;
        }

        private IQueryable<Dron> GetAllDrons()
        {
            return _dbContext.Drons
                .Include(t => t.DronModel)
                .Include(t => t.DronModel).ThenInclude(t => t.DronCompany)
                .Include(t => t.DronModel).ThenInclude(t => t.DronType)
                .Include(t => t.Customer)
                .AsQueryable();
        }

        private void FillDronQueryParams(DronsFilterParams filterParams)
        {
            var predicate = PredicateBuilder.New<Dron>();

            if (!string.IsNullOrEmpty(filterParams.CustomerId))
            {
                predicate = predicate.Extend(t => t.CustomerId == filterParams.CustomerId);
            }

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                predicate = predicate.Extend(t => t.DronModel.Name.Contains(filterParams.Term));
            }

            if (filterParams.DronModelId.HasValue)
            {
                predicate = predicate.Extend(t => t.DronModelId == filterParams.DronModelId.Value);
            }

            if (filterParams.DronCompanyId.HasValue)
            {
                predicate = predicate.Extend(t => t.DronModel.DronCompanyId == filterParams.DronCompanyId.Value);
            }

            if (filterParams.DronTypeId.HasValue)
            {
                predicate = predicate.Extend(t => t.DronModel.DronTypeId == filterParams.DronTypeId.Value);
            }

            filterParams.Expression = predicate;
        }
    }
}
