using SAT.Domain.AirTaxies;
using System;

namespace SAT.Domain.Params
{
    public class TaxiesFilterParams : FilterParams<AirTaxi>
    {
        public string CustomerId { get; set; }

        public int[] SelectedTypeIds { get; set; }

        public int[] SelectedCompanyIds { get; set; }

        public int[] SelectedModelIds { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string Term { get; set; }
    }
}
