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
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    { 
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(b => b.Id);
            
            builder.Property(c=>c.Id).UseIdentityColumn();
            
            builder.Property(c=>c.Description).HasMaxLength(100).IsRequired(false);
            builder.Property(c => c.ModelYear).HasMaxLength(4).IsRequired();
            builder.Property(c => c.Model).HasMaxLength(50).IsRequired();     
            builder.Property(c => c.DailyPrice).IsRequired();
            






            //Relationships


            builder.HasOne(c => c.Brand).WithMany(b => b.Cars);
            builder.HasOne(c => c.Color).WithMany(co => co.Cars);
            

        }
    }
}
