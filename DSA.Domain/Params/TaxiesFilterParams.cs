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

        public DateTime? Start { get; set; }

        public DateTime? End { get; set; }

        public string Term { get; set; }
    }
}
