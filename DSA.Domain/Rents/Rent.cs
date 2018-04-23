using System;
using DSA.Domain.Customers;
using DSA.Domain.Drons;

namespace DSA.Domain.Rents
{
    public class Rent
    {
        public int RentId { get; set; }

        public string CustomerId { get; set; }

        public int DronId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Customer Customer { get; set; }

        public Dron Dron { get; set; }
    }
}
