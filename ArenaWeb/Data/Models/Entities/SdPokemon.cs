using ArenaWeb.Data.Models.Codes;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArenaWeb.Data.Models.Entities
{
	public class SdPokemon
	{
		#region Properties

		[Column(TypeName = "numeric(18,0)")]
		public decimal SdPokemon_Id { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public PokemonType Type { get; set; }

		public double HP { get; set; }

		public PokemonRarity Rarity { get; set; }

		public double ATK { get; set; }

		#endregion
	}
}