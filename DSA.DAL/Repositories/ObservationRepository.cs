using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.DAL.Repositories
{
    public class ObservationRepository : Repository<Observation>, IObservationRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public ObservationRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IEnumerable<Observation> GetResidentObservations(ObservationParams observationParams)
        {
            var pbservations = GetAllObservations();

            var query = FillObservationQueryParams(observationParams);

            pbservations = pbservations.Where(query);

            var totalCount = pbservations.Count();

            var result = pbservations
                .OrderByDescending(t => t.RecordedDate)
                .AsNoTracking()
                .ToList();

            return result;
        }

        private IQueryable<Observation> GetAllObservations()
        {
            return _dbContext.Observations.AsQueryable();
        }

        private Expression<Func<Observation, bool>> FillObservationQueryParams(ObservationParams filterParams)
        {
            var predicate = PredicateBuilder.True<Observation>();

            predicate = predicate.Extend(t => t.ResidentId == filterParams.ResidentId);

            if (filterParams.StartDate.HasValue && filterParams.EndDate.HasValue)
            {
                predicate = predicate.Extend(t => t.RecordedDate >= filterParams.StartDate.Value && t.RecordedDate <= filterParams.EndDate.Value);
            }

            return predicate;
        }
    }
}
