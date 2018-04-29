using System.Collections.Generic;
using SAT.Domain.Rents;
using SAT.Domain.Customers;

namespace SAT.Domain.AirTaxies
{
    public class AirTaxi
    {
        public int AirTaxiId { get; set; }

        public string CustomerId { get; set; }

        public int AirTaxiModelId { get; set; }

        public double DailyCosts { get; set; }

        public Customer Customer { get; set; }

        public AirTaxiModel AirTaxiModel { get; set; }

        public ICollection<Rent> Rents { get; set; }

        public AirTaxi()
        {
            Rents = new List<Rent>();
        }
    }
}
