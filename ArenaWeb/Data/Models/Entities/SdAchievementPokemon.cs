using System.ComponentModel.DataAnnotations.Schema;

namespace ArenaWeb.Data.Models.Entities
{
	public class SdAchievementPokemon
	{
		[Column(TypeName = "numeric(18,0)")]
		public decimal SdAchievement_Id { get; set; }

		public decimal SdPokemon_Id { get; set; }

		public virtual SdAchievement SdAchievement { get; set; }

		public virtual SdPokemon SdPokemon { get; set; }
	}
}