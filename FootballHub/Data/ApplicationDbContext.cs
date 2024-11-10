using FootballHub.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FootballHub.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Opponent> Opponents { get; set;}
        public DbSet<Fixture> Fixtures { get; set; }
    }
}
