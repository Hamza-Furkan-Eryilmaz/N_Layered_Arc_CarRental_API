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
    internal class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(b => b.Id);
            
            builder.Property(co => co.Id).UseIdentityColumn();

            builder.Property(co=>co.ColorName).IsRequired().HasMaxLength(25);

            //Reliationships

            builder.HasMany(co => co.Cars).WithOne(c => c.Color);

        }
    }
}
