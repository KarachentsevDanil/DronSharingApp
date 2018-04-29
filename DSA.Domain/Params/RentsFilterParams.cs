using SAT.Domain.Rents;

namespace SAT.Domain.Params
{
    public class RentsFilterParams : FilterParams<Rent>
    {
        public string CustomerId { get; set; }
        
        public int? AirTaxiModelId { get; set; }

        public string Term { get; set; }
    }
}
