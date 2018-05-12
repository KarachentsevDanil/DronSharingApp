using SAT.Domain.Rents;
using System;

namespace SAT.Domain.Params
{
    public class RentsFilterParams : FilterParams<Rent>
    {
        public string CustomerId { get; set; }
        
        public int? AirTaxiId { get; set; }

        public bool IsCalendarView { get; set; }

        public string Term { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
