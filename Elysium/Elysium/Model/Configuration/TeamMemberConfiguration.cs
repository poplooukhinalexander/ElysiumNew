using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Elysium.Model.Configuration
{
    public class TeamMemberConfiguration : IEntityTypeConfiguration<TeamMember>
    {
        public void Configure(EntityTypeBuilder<TeamMember> builder)
        {
            builder.Property(_ => _.Name).IsRequired().HasMaxLength(50);
            builder.Property(_ => _.PhotoLink).HasMaxLength(512);
            builder.Property(_ => _.Profession).IsRequired().HasMaxLength(100);
            builder.Property(_ => _.Description).HasMaxLength(200);
            builder.Property(_ => _.Email).HasMaxLength(256);
            builder.Property(_ => _.Phone).HasMaxLength(15);
        }
    }
}
