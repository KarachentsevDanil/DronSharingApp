using Autofac;
using DSA.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DSA.WebApi.Modules
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(CreateDbContextOptions).As<DbContextOptions<DronSharingContext>>();
        }

        private static DbContextOptions<DronSharingContext> CreateDbContextOptions(IComponentContext context)
        {
            var configuration = context.Resolve<IConfiguration>();
            string connectionString = configuration["Data:DefaultConnection:ConnectionString"];

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<DronSharingContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);

            using (var dbContext = new DronSharingContext(dbContextOptionsBuilder.Options))
            {
                dbContext.Database.EnsureCreated();
            }

            return dbContextOptionsBuilder.Options;
        }
        
    }
}
