using SAT.DAL.Context.Mappings.Contract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SAT.Domain.Customers;

namespace SAT.DAL.Context.Mappings
{
    public class CustomerMapping : IMappingContract<Customer>
    {
        public void MapEntity(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "core");
        }
    }
}
