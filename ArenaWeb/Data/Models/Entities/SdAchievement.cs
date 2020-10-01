using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArenaWeb.Data.Models.Entities
{
	public class SdAchievement
	{
		[Column(TypeName = "numeric(18,0)")]
		public decimal SdAchievement_Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public string NPCName { get; set; }

		public short? UnlockedOnCount { get; set; }

		public virtual ICollection<SdAchievementPokemon> SdAchievementPokemon { get; set; }
	}
}