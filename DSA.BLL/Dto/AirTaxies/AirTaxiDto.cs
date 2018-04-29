namespace SAT.BLL.Dto.AirTaxies
{
    public class AirTaxiDto
    {
        public int AirTaxiId { get; set; }

        public string CustomerId { get; set; }

        public int AirTaxiModelId { get; set; }

        public double DailyCosts { get; set; }

        public string CustomerName { get; set; }

        public string AirTaxiModelName { get; set; }

        public string AirTaxiCompanyName { get; set; }

        public string AirTaxiTypeName { get; set; }

        public string AirTaxiPhoto { get; set; }

        public string AirTaxiDescription { get; set; }

        public int AirTaxiCapacity { get; set; }

        public int AirTaxiMaximumRangeFlight { get; set; }
    }
}
