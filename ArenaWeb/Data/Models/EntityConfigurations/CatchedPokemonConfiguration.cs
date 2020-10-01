using ArenaWeb.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArenaWeb.Data.Models.EntityConfigurations
{
    public class CatchedPokemonConfiguration : IEntityTypeConfiguration<CatchedPokemon>
    {
        public void Configure(EntityTypeBuilder<CatchedPokemon> builder)
        {
            builder.ToTable("CatchedPokemon").HasKey(c => c.CatchedPokemon_Id);

            builder.HasOne(c => c.SdPokemon).WithMany().HasForeignKey(c => c.SdPokemon_Id);
            builder.HasOne(c => c.Twitchuser).WithMany(u => u.CatchedPokemon).HasForeignKey(c => c.Twitchuser_Id);
        }
    }
}