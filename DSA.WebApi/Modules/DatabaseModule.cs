using Autofac;
using SAT.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SAT.WebApi.Modules
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(CreateDbContextOptions).As<DbContextOptions<AirTaxiSharingContext>>();
        }

        private static DbContextOptions<AirTaxiSharingContext> CreateDbContextOptions(IComponentContext context)
        {
            var configuration = context.Resolve<IConfiguration>();
            string connectionString = configuration["Data:DefaultConnection:ConnectionString"];

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<AirTaxiSharingContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);

            using (var dbContext = new AirTaxiSharingContext(dbContextOptionsBuilder.Options))
            {
                dbContext.Database.EnsureCreated();
            }

            return dbContextOptionsBuilder.Options;
        }
        
    }
}
