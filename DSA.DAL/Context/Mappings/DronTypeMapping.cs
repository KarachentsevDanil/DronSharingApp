using DSA.DAL.Context.Mappings.Contract;
using DSA.Domain.Drons;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSA.DAL.Context.Mappings
{
    public class DronTypeMapping : IMappingContract<DronType>
    {
        public void MapEntity(EntityTypeBuilder<DronType> builder)
        {
            builder.ToTable("DronTypes", "core");

            builder.HasKey(x => x.DronTypeId);
        }
    }
}
