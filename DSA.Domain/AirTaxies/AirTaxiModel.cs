using System.Collections.Generic;

namespace SAT.Domain.AirTaxies
{
    public class AirTaxiModel
    {
        public int AirTaxiModelId { get; set; }

        public int AirTaxiCompanyId { get; set; }

        public int AirTaxiTypeId { get; set; }

        public string Name { get; set; }
        
        public byte[] Photo { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

        public int MaximumRangeFlight { get; set; }

        public AirTaxiCompany Company { get; set; }

        public AirTaxiType Type { get; set; }
        
        public ICollection<AirTaxi> AirTaxies { get; set; }

        public AirTaxiModel()
        {
            AirTaxies = new List<AirTaxi>();
        }
    }
}
