using DSA.Domain.Drons;

namespace DSA.Domain.Params
{
    public class DronsFilterParams : FilterParams<Dron>
    {
        public string CustomerId { get; set; }

        public int? DronTypeId { get; set; }

        public int? DronCompanyId { get; set; }

        public int? DronModelId { get; set; }

        public string Term { get; set; }
    }
}
