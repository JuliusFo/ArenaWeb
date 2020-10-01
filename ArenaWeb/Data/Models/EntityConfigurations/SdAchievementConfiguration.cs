using ArenaWeb.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArenaWeb.Data.Models.EntityConfigurations
{
    public class SdAchievementConfiguration : IEntityTypeConfiguration<SdAchievement>
    {
        public void Configure(EntityTypeBuilder<SdAchievement> builder)
        {
            builder.ToTable("SdAchievement").HasKey(u => u.SdAchievement_Id);
        }
    }
}