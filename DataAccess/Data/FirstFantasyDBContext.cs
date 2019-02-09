using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Data
{
    public class FirstFantasyDBContext : DbContext
    {
        public DbSet<LevelText> LevelText { get; set; }

        public FirstFantasyDBContext(DbContextOptions<FirstFantasyDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LevelText>().ToTable("LevelText");
        }
    }
}
