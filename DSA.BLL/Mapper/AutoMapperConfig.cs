namespace SAT.BLL.Mapper
{
    public class AutoMapperConfig
    {
        public static void Init()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CustomerAutoMapperProfile>();
                cfg.AddProfile<AirTaxiAutoMapperProfile>();
                cfg.AddProfile<RentAutoMapperProfile>();
            });

            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}
