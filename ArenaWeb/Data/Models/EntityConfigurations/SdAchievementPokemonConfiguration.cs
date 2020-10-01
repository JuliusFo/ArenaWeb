using ArenaWeb.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArenaWeb.Data.Models.EntityConfigurations
{
    public class SdAchievementPokemonConfiguration : IEntityTypeConfiguration<SdAchievementPokemon>
    {
        public void Configure(EntityTypeBuilder<SdAchievementPokemon> builder)
        {
            builder.ToTable("SdAchievementPokemon").HasKey(c => c.SdAchievement_Id);

            builder.HasOne(c => c.SdPokemon).WithMany().HasForeignKey(c => c.SdPokemon_Id);
            builder.HasOne(c => c.SdAchievement).WithMany(a => a.SdAchievementPokemon).HasForeignKey(c => c.SdAchievement_Id);
        }
    }
}