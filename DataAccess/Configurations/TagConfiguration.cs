using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfDataAccess.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(p => p.Content).IsRequired().HasMaxLength(25);
            builder.Property(p => p.CreatedAt).IsRequired().HasDefaultValueSql("GETDATE()");
            builder.Property(p => p.IsDeleted).HasDefaultValue(false);
            builder.HasMany(t => t.PostTags).WithOne(pt => pt.Tag).HasForeignKey(pt => pt.TagId).OnDelete(DeleteBehavior.Cascade);
            builder.HasKey(p => p.Id);
        }
    }
}
