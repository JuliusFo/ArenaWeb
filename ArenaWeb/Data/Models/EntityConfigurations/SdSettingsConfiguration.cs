using ArenaWeb.Data.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArenaWeb.Data.Models.EntityConfigurations
{
    public class SdSettingsConfiguration : IEntityTypeConfiguration<SdSettings>
    {
        public void Configure(EntityTypeBuilder<SdSettings> builder)
        {
            builder.ToTable("SdSettings").HasKey(s => s.SdSettingsId);
        }
    }
}