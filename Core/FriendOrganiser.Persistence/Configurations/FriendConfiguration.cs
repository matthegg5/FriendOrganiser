
using FriendOrganiser.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FriendOrganiser.Infrastructure.Persistence.Configurations
{
    public class FriendConfiguration
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);


            builder.Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}