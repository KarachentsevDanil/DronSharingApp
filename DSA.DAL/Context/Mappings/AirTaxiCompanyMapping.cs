using SAT.DAL.Context.Mappings.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAT.Domain.AirTaxies;

namespace SAT.DAL.Context.Mappings
{
    public class AirTaxiCompanyMapping : IMappingContract<AirTaxiCompany>
    {
        public void MapEntity(EntityTypeBuilder<AirTaxiCompany> builder)
        {
            builder.ToTable("AirTaxiCompanys", "core");

            builder.HasKey(x => x.AirTaxiCompanyId);
        }
    }
}
