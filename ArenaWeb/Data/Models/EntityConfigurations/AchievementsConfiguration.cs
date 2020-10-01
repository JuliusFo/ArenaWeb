using ArenaWeb.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArenaWeb.Data.Models.EntityConfigurations
{
    public class AchievementsConfiguration : IEntityTypeConfiguration<Achievements>
    {
        public void Configure(EntityTypeBuilder<Achievements> builder)
        {
            builder.ToTable("Achievements").HasKey(u => u.Achievement_Id);

            builder.HasOne(a => a.SdAchievement).WithMany().HasForeignKey(a => a.SdAchievment_Id);
            builder.HasOne(a => a.Twitchuser).WithMany(u => u.Achievements).HasForeignKey(a => a.Twitchuser_Id);
        }
    }
}