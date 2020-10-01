﻿using ArenaWeb.Data.Models.Entities;
using ArenaWeb.Data.Models.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ArenaWeb.Data
{
    public class AppDbContext : DbContext
    {
        #region Fields



        #endregion

        #region Constructor

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        #endregion

        #region Properties

        public DbSet<Twitchuser> Twitchuser { get; set; }

        public DbSet<SdPokemon> SdPokemon { get; set; }

        public DbSet<SdAchievement> SdAchievement { get; set; }

        public DbSet<CatchedPokemon> CatchedPokemon { get; set; }

        public DbSet<Achievements> Achievements { get; set; }

        public DbSet<SdAchievementPokemon> SdAchievementPokemon { get; set; }

        public DbSet<SdSettings> SdSettings { get; set; }

        #endregion

        #region Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TwitchuserConfiguration());
            modelBuilder.ApplyConfiguration(new SdPokemonConfiguration());
            modelBuilder.ApplyConfiguration(new SdAchievementConfiguration());
            modelBuilder.ApplyConfiguration(new CatchedPokemonConfiguration());
            modelBuilder.ApplyConfiguration(new AchievementsConfiguration());
            modelBuilder.ApplyConfiguration(new SdAchievementPokemonConfiguration());
            modelBuilder.ApplyConfiguration(new SdAchievementPokemonConfiguration());
        }

        #endregion

    }
}