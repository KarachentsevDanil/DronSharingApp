namespace SAT.BLL.Dto.AirTaxies
{
    public class AirTaxiModelDto
    {
        public int AirTaxiModelId { get; set; }

        public int AirTaxiCompanyId { get; set; }

        public int AirTaxiTypeId { get; set; }

        public string AirTaxiCompanyName { get; set; }

        public string AirTaxiTypeName { get; set; }

        public string Name { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }

        public int Capacity { get; set; }

        public int MaximumRangeFlight { get; set; }
    }
}
