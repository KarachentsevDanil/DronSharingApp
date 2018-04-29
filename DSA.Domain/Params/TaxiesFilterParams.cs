using SAT.Domain.AirTaxies;

namespace SAT.Domain.Params
{
    public class TaxiesFilterParams : FilterParams<AirTaxi>
    {
        public string CustomerId { get; set; }

        public int? AirTaxiTypeId { get; set; }

        public int? AirTaxiCompanyId { get; set; }

        public int? AirTaxiModelId { get; set; }

        public string Term { get; set; }
    }
}
