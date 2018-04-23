using System.Collections.Generic;
using DSA.Domain.Customers;
using DSA.Domain.Rents;

namespace DSA.Domain.Drons
{
    public class Dron
    {
        public int DronId { get; set; }

        public string CustomerId { get; set; }

        public int DronModelId { get; set; }

        public double DailyCosts { get; set; }

        public Customer Customer { get; set; }

        public DronModel DronModel { get; set; }

        public ICollection<Rent> Rents { get; set; }

        public Dron()
        {
            Rents = new List<Rent>();
        }
    }
}
