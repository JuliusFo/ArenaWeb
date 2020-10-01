﻿using ArenaWeb.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArenaWeb.Data.Models.EntityConfigurations
{
    public class SdPokemonConfiguration : IEntityTypeConfiguration<SdPokemon>
    {
        public void Configure(EntityTypeBuilder<SdPokemon> builder)
        {
            builder.ToTable("SdPokemon").HasKey(u => u.SdPokemon_Id);
            builder.Property(p => p.Type).HasConversion<int>();
            builder.Property(p => p.Rarity).HasConversion<int>();
        }
    }
}