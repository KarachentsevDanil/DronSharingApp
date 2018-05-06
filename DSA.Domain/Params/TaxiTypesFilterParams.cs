using SAT.Domain.AirTaxies;

namespace SAT.Domain.Params
{
    public class TaxiTypesFilterParams : FilterParams<AirTaxiType>
    {
        public string Term { get; set; }
    }
}
