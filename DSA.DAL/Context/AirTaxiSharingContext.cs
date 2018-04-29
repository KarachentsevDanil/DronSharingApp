using SAT.DAL.Context.Mappings;
using SAT.Domain.Rents;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SAT.Domain.AirTaxies;
using SAT.Domain.Customers;

namespace SAT.DAL.Context
{
    public class AirTaxiSharingContext : IdentityDbContext<Customer>
    {
        public AirTaxiSharingContext(DbContextOptions<AirTaxiSharingContext> options) : base(options)
        { }
        
        public DbSet<Customer> Customers { get; set; }

        public DbSet<AirTaxi> AirTaxi { get; set; }

        public DbSet<AirTaxiModel> AirTaxiModels { get; set; }

        public DbSet<AirTaxiType> AirTaxiTypes { get; set; }

        public DbSet<AirTaxiCompany> AirTaxiCompanys { get; set; }

        public DbSet<Rent> Rents { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new CustomerMapping().MapEntity(builder.Entity<Customer>());
            new AirTaxiMapping().MapEntity(builder.Entity<AirTaxi>());
            new AirTaxiModelMapping().MapEntity(builder.Entity<AirTaxiModel>());
            new AirTaxiCompanyMapping().MapEntity(builder.Entity<AirTaxiCompany>());
            new AirTaxiTypeMapping().MapEntity(builder.Entity<AirTaxiType>());
            new RentMapping().MapEntity(builder.Entity<Rent>());
        }
    }
}
