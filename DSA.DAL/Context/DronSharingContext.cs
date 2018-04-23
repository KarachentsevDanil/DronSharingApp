using DSA.DAL.Context.Mappings;
using DSA.Domain.Customers;
using DSA.Domain.Drons;
using DSA.Domain.Rents;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DSA.DAL.Context
{
    public class DronSharingContext : IdentityDbContext<Customer>
    {
        public DronSharingContext(DbContextOptions<DronSharingContext> options) : base(options)
        { }
        
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Dron> Drons { get; set; }

        public DbSet<DronModel> DronModels { get; set; }

        public DbSet<DronType> DronTypes { get; set; }

        public DbSet<DronCompany> DronCompanys { get; set; }

        public DbSet<Rent> Rents { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new CustomerMapping().MapEntity(builder.Entity<Customer>());
            new DronMapping().MapEntity(builder.Entity<Dron>());
            new DronModelMapping().MapEntity(builder.Entity<DronModel>());
            new DronCompanyMapping().MapEntity(builder.Entity<DronCompany>());
            new DronTypeMapping().MapEntity(builder.Entity<DronType>());
            new RentMapping().MapEntity(builder.Entity<Rent>());
        }
    }
}
