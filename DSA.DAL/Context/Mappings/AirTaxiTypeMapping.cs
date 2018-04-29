using SAT.DAL.Context.Mappings.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAT.Domain.AirTaxies;

namespace SAT.DAL.Context.Mappings
{
    public class AirTaxiTypeMapping : IMappingContract<AirTaxiType>
    {
        public void MapEntity(EntityTypeBuilder<AirTaxiType> builder)
        {
            builder.ToTable("AirTaxiTypes", "core");

            builder.HasKey(x => x.AirTaxiTypeId);
        }
    }
}
