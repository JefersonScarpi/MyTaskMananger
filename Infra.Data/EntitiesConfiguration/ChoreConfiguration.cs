using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.EntitiesConfiguration
{
    class ChoreConfiguration : IEntityTypeConfiguration<Chore>
    {
        public void Configure(EntityTypeBuilder<Chore> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Title).HasMaxLength(20).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(100).IsRequired();

            builder.HasOne(e => e.ListIndex).WithMany(e => e.Chores).HasForeignKey(e => e.ListIndexId);

            


        }
    }
}
