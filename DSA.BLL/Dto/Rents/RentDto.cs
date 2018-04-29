using System;

namespace SAT.BLL.Dto.Rents
{
    public class RentDto
    {
        public int RentId { get; set; }

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int AirTaxiId { get; set; }

        public string AirTaxiModel { get; set; }

        public string AirTaxiType { get; set; }

        public string AirTaxiCompany { get; set; }
        
        public double AirTaxiDailyCosts { get; set; }

        public string AirTaxiPhoto { get; set; }

        public string AirTaxiDescription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int RentDaysCount { get; set; }
    }
}
