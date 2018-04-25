using System;

namespace DSA.BLL.Dto.Rents
{
    public class AddRentDto
    {
        public string CustomerId { get; set; }

        public int DronId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}