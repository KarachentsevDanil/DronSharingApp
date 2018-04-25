using Autofac;
using DSA.BLL.Services;
using DSA.BLL.Services.Contracts;

namespace DSA.WebApi.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<DronService>().As<IDronService>();
            builder.RegisterType<DronModelService>().As<IDronModelService>();
            builder.RegisterType<DronCompanyService>().As<IDronCompanyService>();
            builder.RegisterType<DronTypeService>().As<IDronTypeService>();
            builder.RegisterType<RentService>().As<IRentService>();
        }
    }
}
