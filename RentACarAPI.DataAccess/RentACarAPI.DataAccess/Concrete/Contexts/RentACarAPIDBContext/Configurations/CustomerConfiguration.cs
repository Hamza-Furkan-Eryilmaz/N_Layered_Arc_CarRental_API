using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACarAPI.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.DataAccess.Concrete.Contexts.RentACarAPIDBContext.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(cu => cu.Id).UseIdentityColumn();

            builder.Property(cu=>cu.CustomerName).IsRequired().HasMaxLength(60);

            //Reliationships

            builder.HasMany(cu => cu.Rentals).WithOne(r => r.customer);

        }
    }
}
