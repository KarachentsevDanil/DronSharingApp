using SAT.Domain.Rents;
using System;

namespace SAT.BLL.Dto.Rents
{
    public class AddRentDto
    {
        public string CustomerId { get; set; }

        public int AirTaxiId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public RentStatus Status { get; set; }
    }
}