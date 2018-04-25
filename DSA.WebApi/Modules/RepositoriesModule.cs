using Autofac;
using DSA.DAL.Context;
using DSA.DAL.Repositories;
using DSA.DAL.Repositories.Contract;
using DSA.DAL.UnitOfWork;
using DSA.DAL.UnitOfWork.Contract;

namespace DSA.WebApi.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DronSharingContext>().As<DronSharingContext>().InstancePerLifetimeScope();

            builder.RegisterType<DronSharingUnitOfWork>().As<IDronSharingUnitOfWork>().PropertiesAutowired();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<DronRepository>().As<IDronRepository>();
            builder.RegisterType<DronTypeRepository>().As<IDronTypeRepository>();
            builder.RegisterType<DronCompanyRepository>().As<IDronCompanyRepository>();
            builder.RegisterType<DronModelRepository>().As<IDronModelRepository>();
            builder.RegisterType<RentRepository>().As<IRentRepository>();
        }
    }
}
