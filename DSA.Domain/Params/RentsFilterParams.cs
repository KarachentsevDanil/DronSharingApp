using DSA.Domain.Rents;

namespace DSA.Domain.Params
{
    public class RentsFilterParams : FilterParams<Rent>
    {
        public string CustomerId { get; set; }
        
        public int? DronModelId { get; set; }

        public string Term { get; set; }
    }
}
