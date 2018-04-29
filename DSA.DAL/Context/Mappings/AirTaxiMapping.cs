using SAT.DAL.Context.Mappings.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAT.Domain.AirTaxies;

namespace SAT.DAL.Context.Mappings
{
    public class AirTaxiMapping : IMappingContract<AirTaxi>
    {
        public void MapEntity(EntityTypeBuilder<AirTaxi> builder)
        {
            builder.ToTable("AirTaxies", "core");

            builder.HasKey(x => x.AirTaxiId);

            builder.HasOne(x => x.AirTaxiModel).WithMany(x => x.AirTaxies).HasForeignKey(x => x.AirTaxiModelId);

            builder.HasOne(x => x.Customer).WithMany(x => x.Taxies).HasForeignKey(x => x.CustomerId);
        }
    }
}
