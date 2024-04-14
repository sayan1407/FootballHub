﻿using FootballHub.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<News> News { get; set; }
    }
}
