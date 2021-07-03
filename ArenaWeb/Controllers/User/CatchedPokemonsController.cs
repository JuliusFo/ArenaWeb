using ArenaWeb.Data;
using ArenaWeb.Transfer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaWeb.Controllers.User
{
	public class CatchedPokemonsController : Controller
	{
		private readonly AppDbContext context;

		public CatchedPokemonsController(AppDbContext context)
		{
			this.context = context;
		}

		// GET: CatchedPokemons
		public async Task<IActionResult> Index()
		{
			var userId = User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault()?.Value;
			var catchedPokemonQuery = context.Twitchuser.Where(tu => tu.Twitchuser_Id == userId);
			var catchedPokemonResult = await catchedPokemonQuery.SelectMany(u => u.CatchedPokemon.Select(c => new TransferDexElement()
			{
				Id = c.SdPokemon.SdPokemon_Id,
				Number = c.SdPokemon.Number.ToString(),
				Name = c.SdPokemon.Name,
				Amount = c.Pokemon_AmountCatched
			})).ToListAsync();

			var pokedexQuery = context.SdPokemon.Select(s => new TransferDexElement()
			{
				Id = s.SdPokemon_Id,
				Number = s.Number.ToString(),
				Name = s.Name
			});

			var pokedexResult = await pokedexQuery.ToListAsync();

			foreach (var entry in pokedexResult)
			{
				var catchedElement = catchedPokemonResult.FirstOrDefault(e => e.Id == entry.Id);

				if (null != catchedElement)
				{
					entry.Amount = catchedElement.Amount;
				}
				else
				{
					entry.Amount = 0;
				}
			}

			return View(pokedexResult);
		}

		[HttpPost]
		public async Task<IActionResult> AddToTeam(decimal id)
		{
			return null;
		}

		[HttpPost]
		public async Task<IActionResult> RemoveFromTeam(decimal id)
		{
			return null;
		}
	}
}