using DSA.DAL.Context.Mappings.Contract;
using DSA.Domain.Rents;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSA.DAL.Context.Mappings
{
    public class RentMapping : IMappingContract<Rent>
    {
        public void MapEntity(EntityTypeBuilder<Rent> builder)
        {
            builder.ToTable("Rents", "core");

            builder.HasKey(x => x.RentId);

            builder.HasOne(x => x.Dron).WithMany(x => x.Rents).HasForeignKey(x => x.DronId);

            builder.HasOne(x => x.Customer).WithMany(x => x.Rents).HasForeignKey(x => x.CustomerId);
        }
    }
}
