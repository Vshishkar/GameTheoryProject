using GameTheoryProject.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameTheoryProject.Database.Configuration
{
    public class GameConfiguration : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(x => x.GameId);
            builder.HasMany<UserGameResponse>(x => x.UserGameResponses)
                .WithOne(x => x.Game)
                .HasForeignKey(x => x.GameId);
        }
    }
}