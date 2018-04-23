using DSA.DAL.Context.Mappings.Contract;
using DSA.Domain.Drons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSA.DAL.Context.Mappings
{
    public class DronMapping : IMappingContract<Dron>
    {
        public void MapEntity(EntityTypeBuilder<Dron> builder)
        {
            builder.ToTable("Drons", "core");

            builder.HasKey(x => x.DronId);

            builder.HasOne(x => x.DronModel).WithMany(x => x.Drons).HasForeignKey(x => x.DronModelId);

            builder.HasOne(x => x.Customer).WithMany(x => x.Drons).HasForeignKey(x => x.CustomerId);
        }
    }
}
