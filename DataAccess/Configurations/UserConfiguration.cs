using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(con => con.LastName).IsRequired().HasMaxLength(30);
            builder.Property(con => con.Password).IsRequired().HasMaxLength(30);
            builder.Property(con => con.UserName).IsRequired().HasMaxLength(20);
            builder.Property(con => con.FirstName).IsRequired().HasMaxLength(20);
            builder.HasIndex(con => con.UserName).IsUnique();
            builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.HasMany(p => p.UserUseCases).WithOne(uc => uc.User).HasForeignKey(uc => uc.UserId);
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
            builder.HasIndex(u => u.Id).IsUnique();
            builder.HasKey(p => p.Id);
        }
    }
}
