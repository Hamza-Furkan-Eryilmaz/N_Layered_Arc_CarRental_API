using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACarAPI.Core.Entities.Concrete;
using RentACarAPI.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarAPI.DataAccess.Concrete.Contexts.RentACarAPIDBContext.Configurations
{
    public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {

            builder.HasKey(b => b.Id);
            builder.Property(u => u.Id).UseIdentityColumn();
           
            builder.Property(u => u.Name).HasMaxLength(50).IsRequired();
        }
    }
}
