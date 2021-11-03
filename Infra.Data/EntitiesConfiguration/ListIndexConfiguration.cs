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
    public class ListIndexConfiguration : IEntityTypeConfiguration<ListIndex>
    {
        public void Configure(EntityTypeBuilder<ListIndex> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            builder.HasData( 
                new ListIndex(1, "Lista 01"),
                new ListIndex(2, "Lista 02"),
                new ListIndex(3, "Lista 03"));
        }
    }
}
