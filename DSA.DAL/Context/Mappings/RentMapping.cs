using SAT.DAL.Context.Mappings.Contract;
using SAT.Domain.Rents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SAT.DAL.Context.Mappings
{
    public class RentMapping : IMappingContract<Rent>
    {
        public void MapEntity(EntityTypeBuilder<Rent> builder)
        {
            builder.ToTable("Rents", "core");

            builder.HasKey(x => x.RentId);

            builder.HasOne(x => x.AirTaxi).WithMany(x => x.Rents).HasForeignKey(x => x.AirTaxiId);

            builder.HasOne(x => x.Customer).WithMany(x => x.Rents).HasForeignKey(x => x.CustomerId);
        }
    }
}
