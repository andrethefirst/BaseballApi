using Microsoft.EntityFrameworkCore;

namespace BaseballPlayer.Models
{
  public class BaseballPlayerContext : DbContext
  {
    public BaseballPlayerContext(DbContextOptions<BaseballPlayerContext> options)
      : base(options)
      {
      }
      public DbSet<Player> Players {get; set;}

      protected override void OnModelCreating(ModelBuilder builder)
      {
        builder.Entity<Player>()
          .HasData(
            new Player {PlayerId = 1, Name = "Mike Trout", JerseyNumber = 27, Team = "Angels", Position = "CF" }, 
            new Player {PlayerId = 2, Name = "Freddie Freeman", JerseyNumber = 5, Team = "Braves", Position = "1B" },
            new Player {PlayerId = 3, Name = "Cliff Lee", JerseyNumber = 34, Team = "Phillies", Position = "Pitcher" },
            new Player {PlayerId = 4, Name = "Vladimir Guerrero", JerseyNumber = 27, Team = "Angels", Position = "CF" }
          );
      }
  }
}