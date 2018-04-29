using Autofac;
using SAT.BLL.Services;
using SAT.BLL.Services.Contracts;

namespace SAT.WebApi.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<AirTaxiService>().As<IAirTaxiService>();
            builder.RegisterType<AirTaxiModelService>().As<IAirTaxiModelService>();
            builder.RegisterType<AirTaxiCompanyService>().As<IAirTaxiCompanyService>();
            builder.RegisterType<AirTaxiTypeService>().As<IAirTaxiTypeService>();
            builder.RegisterType<RentService>().As<IRentService>();
        }
    }
}
