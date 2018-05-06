using SAT.Domain.AirTaxies;

namespace SAT.Domain.Params
{
    public class CompaniesFilterParams : FilterParams<AirTaxiCompany>
    {
        public string Term { get; set; }
    }
}
