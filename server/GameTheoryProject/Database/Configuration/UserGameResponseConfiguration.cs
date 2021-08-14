using GameTheoryProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTheoryProject.Database.Configuration
{
    public class UserGameResponseConfiguration : IEntityTypeConfiguration<UserGameResponse>
    {
        public void Configure(EntityTypeBuilder<UserGameResponse> builder)
        {
            builder.HasKey(x => new {x.GameId, x.UserId});
            builder.Property(x => x.Number).IsRequired();
            builder.HasOne<User>(x => x.User)
                .WithMany(x => x.UserGameResponses)
                .HasForeignKey(x => x.UserId);
        }
    }
}