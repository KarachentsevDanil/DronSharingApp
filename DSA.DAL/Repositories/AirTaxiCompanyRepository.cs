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
    public class AirTaxiCompanyRepository : Repository<AirTaxiCompany>, IAirTaxiCompanyRepository
    {
        private readonly AirTaxiSharingContext _dbContext;

        public AirTaxiCompanyRepository(AirTaxiSharingContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<AirTaxiCompany> GetCompanies(string company)
        {
            return _dbContext.AirTaxiCompany.Where(t => t.Name.Contains(company)).OrderBy(t => t.Name).ToList();
        }
        
        public CollectionResult<AirTaxiCompany> GetCompaniesByParams(CompaniesFilterParams parameters)
        {
            var airCopmanies = GetAllCompanies();

            FillAirTaxiQueryParams(parameters);

            airCopmanies = airCopmanies.Where(parameters.Expression);

            var totalCount = airCopmanies.Count();

            var result = airCopmanies
                .OrderBy(x=> x.Name)
                .Skip(parameters.Skip)
                .Take(parameters.Take)
                .AsNoTracking()
                .ToList();

            var companiesResult = new CollectionResult<AirTaxiCompany>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return companiesResult;
        }

        private IQueryable<AirTaxiCompany> GetAllCompanies()
        {
            return _dbContext.AirTaxiCompany.AsQueryable();
        }

        private void FillAirTaxiQueryParams(CompaniesFilterParams filterParams)
        {
            var predicate = PredicateBuilder.True<AirTaxiCompany>();
            
            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                predicate = predicate.Extend(t => t.Name.Contains(filterParams.Term));
            }

            filterParams.Expression = predicate;
        }
    }
}
