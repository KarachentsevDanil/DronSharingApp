using System.Collections.Generic;

namespace SAT.Domain.AirTaxies
{
    public class AirTaxiType
    {
        public int AirTaxiTypeId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<AirTaxiModel> Taxies { get; set; }

        public AirTaxiType()
        {
            Taxies = new List<AirTaxiModel>();
        }
    }
}
