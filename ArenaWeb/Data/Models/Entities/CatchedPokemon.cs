using System.ComponentModel.DataAnnotations.Schema;

namespace ArenaWeb.Data.Models.Entities
{
	public class CatchedPokemon
	{
		[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
		[Column(TypeName = "numeric(18,0)")]
		public decimal CatchedPokemon_Id { get; set; }

		public int Pokemon_AmountCatched { get; set; }

		public int Pokemon_AmountOnFightingTeam { get; set; }

		public decimal SdPokemon_Id { get; set; }

		public string Twitchuser_Id { get; set; }

		public virtual SdPokemon SdPokemon { get; set; }

		public virtual Twitchuser Twitchuser { get; set; }
	}
}