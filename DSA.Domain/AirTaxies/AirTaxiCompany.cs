using System.Collections.Generic;

namespace SAT.Domain.AirTaxies
{
    public class AirTaxiCompany
    {
        public int AirTaxiCompanyId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Country { get; set; }

        public virtual ICollection<AirTaxiModel> TaxiModels { get; set; }

        public AirTaxiCompany()
        {
            TaxiModels = new List<AirTaxiModel>();
        }
    }
}
