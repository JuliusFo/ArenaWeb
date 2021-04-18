using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaWeb.Transfer
{
	public class TransferFightingTeam
	{
		public IEnumerable<TransferDexElement> SelectedPokemon { get; set; } = new List<TransferDexElement>();
	}
}
