using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArenaWeb.Data.Models.Entities
{
	public class Achievements
	{
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		[Column(TypeName = "numeric(18,0)")]
		public decimal Achievement_Id { get; set; }

		public string Twitchuser_Id { get; set; }

		public DateTime? LastFight { get; set; }

		public decimal SdAchievment_Id { get; set; }

		public virtual SdAchievement SdAchievement { get; set; }

		public virtual Twitchuser Twitchuser { get; set; }
	}
}