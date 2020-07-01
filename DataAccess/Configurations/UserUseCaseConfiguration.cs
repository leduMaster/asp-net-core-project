using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class UserUseCaseConfiguration : IEntityTypeConfiguration<UserUseCase>
    {
        public void Configure(EntityTypeBuilder<UserUseCase> builder)
        {            
            builder.HasKey(u => u.UserId);
            builder.HasIndex(u => u.Id).IsUnique();
            builder.HasKey(u => u.Id);
            builder.Property(u => u.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(u => u.IsDeleted).HasDefaultValue(false);
           }
    }
}
