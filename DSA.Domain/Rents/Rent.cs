using System;
using SAT.Domain.AirTaxies;
using SAT.Domain.Customers;

namespace SAT.Domain.Rents
{
    public class Rent
    {
        public int RentId { get; set; }

        public string CustomerId { get; set; }

        public int AirTaxiId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual AirTaxi AirTaxi { get; set; }
    }
}
