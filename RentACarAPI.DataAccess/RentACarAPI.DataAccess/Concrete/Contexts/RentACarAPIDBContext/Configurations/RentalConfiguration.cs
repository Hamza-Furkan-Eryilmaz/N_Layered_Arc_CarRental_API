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
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(r => r.Id).ValueGeneratedOnAdd();
            builder.Property(r => r.Id).UseIdentityColumn();

            //Reliationships

            builder.HasOne(r=>r.car).WithOne(c=>c.Rental).HasForeignKey<Rental>(r=>r.CarId);
            builder.HasOne(r => r.customer).WithMany(cu => cu.Rentals);
        }
    }
}
