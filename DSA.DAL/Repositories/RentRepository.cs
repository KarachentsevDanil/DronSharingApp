using System.Linq;
using DSA.DAL.Context;
using DSA.DAL.Repositories.Contract;
using DSA.Domain.Params;
using DSA.Domain.Rents;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace DSA.DAL.Repositories
{
    public class RentRepository : DronSharingRepository<Rent>, IRentRepository
    {
        private readonly DronSharingContext _dbContext;

        public RentRepository(DronSharingContext dbContext) : base(dbContext)
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
                .Skip(filterParams.PageSize * (filterParams.PageNumber - 1))
                .Take(filterParams.PageSize == 0 ? int.MaxValue : filterParams.PageSize)
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
                .Include(t => t.Dron)
                .Include(t => t.Dron).ThenInclude(t => t.DronModel)
                .Include(t => t.Dron).ThenInclude(t => t.DronModel).ThenInclude(t => t.DronCompany)
                .Include(t => t.Dron).ThenInclude(t => t.DronModel).ThenInclude(t => t.DronType)
                .Include(t => t.Customer)
                .AsQueryable();
        }

        private void FillRentQueryParams(RentsFilterParams filterParams)
        {
            var predicate = PredicateBuilder.New<Rent>();

            if (!string.IsNullOrEmpty(filterParams.CustomerId))
            {
                predicate = predicate.Extend(t => t.CustomerId == filterParams.CustomerId);
            }

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                predicate = predicate.Extend(t => t.Dron.DronModel.Name.Contains(filterParams.Term));
            }

            if (filterParams.DronModelId.HasValue)
            {
                predicate = predicate.Extend(t => t.Dron.DronModelId == filterParams.DronModelId.Value);
            }

            filterParams.Expression = predicate;
        }
    }
}
