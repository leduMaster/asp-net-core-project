using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    class VotesConfiguration : IEntityTypeConfiguration<Votes>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Votes> builder)
        {
            
            builder.HasIndex(u => u.Id).IsUnique();
            builder.Property(u => u.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.IsDeleted).HasDefaultValue(false);
            builder.HasIndex(u => u.Id).IsUnique();
            builder.HasKey(u => u.Id);
        }
    }
}
