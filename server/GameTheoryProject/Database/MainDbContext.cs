using GameTheoryProject.Database.Configuration;
using GameTheoryProject.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTheoryProject.Database
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        
        public DbSet<Game> Games { get; set; }
        
        public DbSet<UserGameResponse> UserGameResponses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}