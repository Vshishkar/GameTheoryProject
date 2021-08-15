using System.Text.RegularExpressions;
using GameTheoryProject.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTheoryProject.Database.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.Username).IsRequired();

            builder.HasKey(x => x.UserId);
        }
    }
}