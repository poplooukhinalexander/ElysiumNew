using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elysium.Model.Configuration
{
    public class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasIndex(_ => _.Name).IsUnique();
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(100);
            builder.Property(_ => _.Phone).IsRequired().HasMaxLength(15);
            builder.Property(_ => _.Email).IsRequired().HasMaxLength(256);
            builder.Property(_ => _.FBId).HasMaxLength(512);
            builder.Property(_ => _.VKId).HasMaxLength(512);
            builder.Property(_ => _.InstagramId).HasMaxLength(512);
            builder.Property(_ => _.Rate).IsRequired().HasDefaultValue(0);
            builder.HasIndex(_ => _.Rate);
        }
    }
}
