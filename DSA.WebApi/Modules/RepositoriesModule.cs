using Autofac;
using SAT.DAL.Context;
using SAT.DAL.Repositories;
using SAT.DAL.Repositories.Contract;
using SAT.DAL.UnitOfWork;
using SAT.DAL.UnitOfWork.Contract;

namespace SAT.WebApi.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AirTaxiSharingContext>().As<AirTaxiSharingContext>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().PropertiesAutowired();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<AirTaxiRepository>().As<IAirTaxiRepository>();
            builder.RegisterType<AirTaxiTypeRepository>().As<IAirTaxiTypeRepository>();
            builder.RegisterType<AirTaxiCompanyRepository>().As<IAirTaxiCompanyRepository>();
            builder.RegisterType<AirTaxiModelRepository>().As<IAirTaxiModelRepository>();
            builder.RegisterType<RentRepository>().As<IRentRepository>();
        }
    }
}
