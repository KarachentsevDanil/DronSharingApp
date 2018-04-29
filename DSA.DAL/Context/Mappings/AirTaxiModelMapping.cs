using SAT.DAL.Context.Mappings.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAT.Domain.AirTaxies;

namespace SAT.DAL.Context.Mappings
{
    public class AirTaxiModelMapping : IMappingContract<AirTaxiModel>
    {
        public void MapEntity(EntityTypeBuilder<AirTaxiModel> builder)
        {
            builder.ToTable("AirTaxiModels", "core");

            builder.HasKey(x => x.AirTaxiModelId);

            builder.HasOne(x => x.Company).WithMany(x => x.TaxiModels).HasForeignKey(x => x.AirTaxiCompanyId);

            builder.HasOne(x => x.Type).WithMany(x => x.Taxies).HasForeignKey(x => x.AirTaxiTypeId);
        }
    }
}
