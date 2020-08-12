using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");
            builder.HasKey(e => e.id);
            builder.HasIndex(e => e.email).IsUnique();
            builder.Property(e => e.name).IsRequired();
            builder.Property(e => e.email).IsRequired();
        }
    }
}
