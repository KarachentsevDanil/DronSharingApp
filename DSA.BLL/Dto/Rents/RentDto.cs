using System;

namespace SAT.BLL.Dto.Rents
{
    public class RentDto
    {
        public int RentId { get; set; }

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerEmail { get; set; }

        public string OwnerId { get; set; }

        public string OwnerName { get; set; }

        public string OwnerEmail { get; set; }

        public int AirTaxiId { get; set; }

        public string AirTaxiModel { get; set; }

        public string AirTaxiType { get; set; }

        public string AirTaxiCompany { get; set; }
        
        public double AirTaxiDailyCosts { get; set; }

        public string AirTaxiPhoto { get; set; }

        public string AirTaxiDescription { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public int RentDaysCount { get; set; }

        public double TotalCosts { get; set; }
    }
}
