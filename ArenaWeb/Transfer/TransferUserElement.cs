using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaWeb.Transfer
{
	public class TransferUserElement
	{
		public string UserName { get; set; }

		public DateTime RegisterDt { get; set; } = DateTime.Now;

		public int TotalPokemonCatched { get; set; }

		public int TotalUniquePokemonCatched { get; set; }

		public int TotalAchievementsUnlocked { get; set; }

		public int TotalAchievementsDone { get; set; }

		public string StarterPokemon { get; set; }

		public int TotalDaysSinceRegister
		{
			get
			{
				return (int)(DateTime.Now - RegisterDt).TotalDays;
			}
		}
	}
}
