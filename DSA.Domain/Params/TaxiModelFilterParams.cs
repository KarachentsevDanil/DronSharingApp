using SAT.Domain.AirTaxies;

namespace SAT.Domain.Params
{
    public class TaxiModelFilterParams : FilterParams<AirTaxiModel>
    {
        public string Term { get; set; }
    }
}
