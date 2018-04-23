using DSA.DAL.Context.Mappings.Contract;
using DSA.Domain.Customers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DSA.DAL.Context.Mappings
{
    public class CustomerMapping : IMappingContract<Customer>
    {
        public void MapEntity(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "core");
        }
    }
}
