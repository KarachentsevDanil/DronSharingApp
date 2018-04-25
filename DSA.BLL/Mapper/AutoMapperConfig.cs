namespace DSA.BLL.Mapper
{
    public class AutoMapperConfig
    {
        public static void Init()
        {
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<CustomerAutoMapperProfile>();
                cfg.AddProfile<DronAutoMapperProfile>();
                cfg.AddProfile<RentAutoMapperProfile>();
            });

            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}
