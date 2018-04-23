using DSA.DAL.Context.Mappings.Contract;
using DSA.Domain.Drons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSA.DAL.Context.Mappings
{
    public class DronCompanyMapping : IMappingContract<DronCompany>
    {
        public void MapEntity(EntityTypeBuilder<DronCompany> builder)
        {
            builder.ToTable("DronCompanys", "core");

            builder.HasKey(x => x.DronCompanyId);
        }
    }
}
