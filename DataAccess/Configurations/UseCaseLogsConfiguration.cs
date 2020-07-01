using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class UseCaseLogsConfiguration : IEntityTypeConfiguration<UseCaseLogs>
    {
        public void Configure(EntityTypeBuilder<UseCaseLogs> builder)
        {
            builder.Property(con => con.Actor).IsRequired().HasMaxLength(30);
            builder.Property(con => con.Data).IsRequired().HasMaxLength(30);
            builder.Property(con => con.UseCaseName).IsRequired().HasMaxLength(20);
            builder.Property(con => con.Date).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.Id);
            builder.HasIndex(u => u.Id).IsUnique();
            builder.HasKey(p => p.Id);
        }
    }
}
