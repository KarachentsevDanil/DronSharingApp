using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RCS.DAL.Context.Mappings.Contract;
using RCS.Domain.Residents;

namespace RCS.DAL.Context.Mappings
{
    public class ResidentDoctorMapping : IMappingContract<ResidentDoctor>
    {
        public void MapEntity(EntityTypeBuilder<ResidentDoctor> builder)
        {
            builder.ToTable("ResidentDoctors", "core");

            builder.HasKey(x => x.ResidentDoctorId);

            builder.HasOne(x => x.Resident).WithMany(x => x.Doctors).HasForeignKey(x => x.ResidentId);

            builder.HasOne(x => x.Doctor).WithMany(x => x.Residents).HasForeignKey(x => x.DoctorId);
        }
    }
}
