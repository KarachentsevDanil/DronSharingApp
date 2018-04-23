using DSA.DAL.Context.Mappings.Contract;
using DSA.Domain.Drons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSA.DAL.Context.Mappings
{
    public class DronModelMapping : IMappingContract<DronModel>
    {
        public void MapEntity(EntityTypeBuilder<DronModel> builder)
        {
            builder.ToTable("DronModels", "core");

            builder.HasKey(x => x.DronModelId);

            builder.HasOne(x => x.DronCompany).WithMany(x => x.Drons).HasForeignKey(x => x.DronCompanyId);

            builder.HasOne(x => x.DronType).WithMany(x => x.Drons).HasForeignKey(x => x.DronTypeId);
        }
    }
}
