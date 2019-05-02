﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ModernStore.Domain.Entities;

namespace ModernStore.Infra.Mappings
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.ToTable("User");
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Username).IsRequired().HasMaxLength(20);
            entityBuilder.Property(x => x.Password).IsRequired().HasMaxLength(32).IsFixedLength();
            entityBuilder.Property(x => x.Active);
            entityBuilder.Property(x => x.Id).IsRequired();
            entityBuilder.Property(x => x.CreatedBy).IsRequired();
            entityBuilder.Property(x => x.UpdatedBy).IsRequired();
            entityBuilder.Property(x => x.CreatedIn).IsRequired();
            entityBuilder.Property(x => x.UpdatedIn).IsRequired();
            //entityBuilder.Ignore(x => x.Notifications);            
        }
    }
}
