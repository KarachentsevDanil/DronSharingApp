using System;

namespace DSA.BLL.Dto.Rents
{
    public class RentDto
    {
        public int RentId { get; set; }

        public string CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int DronId { get; set; }

        public string DronModel { get; set; }

        public string DronType { get; set; }

        public string DronCompany { get; set; }
        
        public double DronDailyCosts { get; set; }

        public string DronPhoto { get; set; }

        public string DronDescription { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int RentDaysCount { get; set; }
    }
}
