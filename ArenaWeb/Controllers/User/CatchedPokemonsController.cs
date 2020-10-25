using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ArenaWeb.Data;
using ArenaWeb.Data.Models.Entities;
using System.Security.Claims;
using ArenaWeb.Transfer;

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
		public async Task<IActionResult> Index(string id)
		{
			var catchedPokemonQuery = context.Twitchuser.Where(tu => tu.Twitchuser_Id == id);
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

		// GET: CatchedPokemons/Details/5
		public async Task<IActionResult> Details(decimal? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var catchedPokemon = await context.CatchedPokemon
				.Include(c => c.SdPokemon)
				.Include(c => c.Twitchuser)
				.FirstOrDefaultAsync(m => m.CatchedPokemon_Id == id);
			if (catchedPokemon == null)
			{
				return NotFound();
			}

			return View(catchedPokemon);
		}

		// GET: CatchedPokemons/Create
		public IActionResult Create()
		{
			ViewData["SdPokemon_Id"] = new SelectList(context.SdPokemon, "SdPokemon_Id", "SdPokemon_Id");
			ViewData["Twitchuser_Id"] = new SelectList(context.Twitchuser, "Twitchuser_Id", "Twitchuser_Id");
			return View();
		}

		// POST: CatchedPokemons/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("CatchedPokemon_Id,Pokemon_AmountCatched,Pokemon_AmountOnFightingTeam,SdPokemon_Id,Twitchuser_Id")] CatchedPokemon catchedPokemon)
		{
			if (ModelState.IsValid)
			{
				context.Add(catchedPokemon);
				await context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["SdPokemon_Id"] = new SelectList(context.SdPokemon, "SdPokemon_Id", "SdPokemon_Id", catchedPokemon.SdPokemon_Id);
			ViewData["Twitchuser_Id"] = new SelectList(context.Twitchuser, "Twitchuser_Id", "Twitchuser_Id", catchedPokemon.Twitchuser_Id);
			return View(catchedPokemon);
		}

		// GET: CatchedPokemons/Edit/5
		public async Task<IActionResult> Edit(decimal? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var catchedPokemon = await context.CatchedPokemon.FindAsync(id);
			if (catchedPokemon == null)
			{
				return NotFound();
			}
			ViewData["SdPokemon_Id"] = new SelectList(context.SdPokemon, "SdPokemon_Id", "SdPokemon_Id", catchedPokemon.SdPokemon_Id);
			ViewData["Twitchuser_Id"] = new SelectList(context.Twitchuser, "Twitchuser_Id", "Twitchuser_Id", catchedPokemon.Twitchuser_Id);
			return View(catchedPokemon);
		}

		// POST: CatchedPokemons/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(decimal id, [Bind("CatchedPokemon_Id,Pokemon_AmountCatched,Pokemon_AmountOnFightingTeam,SdPokemon_Id,Twitchuser_Id")] CatchedPokemon catchedPokemon)
		{
			if (id != catchedPokemon.CatchedPokemon_Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					context.Update(catchedPokemon);
					await context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CatchedPokemonExists(catchedPokemon.CatchedPokemon_Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["SdPokemon_Id"] = new SelectList(context.SdPokemon, "SdPokemon_Id", "SdPokemon_Id", catchedPokemon.SdPokemon_Id);
			ViewData["Twitchuser_Id"] = new SelectList(context.Twitchuser, "Twitchuser_Id", "Twitchuser_Id", catchedPokemon.Twitchuser_Id);
			return View(catchedPokemon);
		}

		// GET: CatchedPokemons/Delete/5
		public async Task<IActionResult> Delete(decimal? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var catchedPokemon = await context.CatchedPokemon
				.Include(c => c.SdPokemon)
				.Include(c => c.Twitchuser)
				.FirstOrDefaultAsync(m => m.CatchedPokemon_Id == id);
			if (catchedPokemon == null)
			{
				return NotFound();
			}

			return View(catchedPokemon);
		}

		// POST: CatchedPokemons/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(decimal id)
		{
			var catchedPokemon = await context.CatchedPokemon.FindAsync(id);
			context.CatchedPokemon.Remove(catchedPokemon);
			await context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CatchedPokemonExists(decimal id)
		{
			return context.CatchedPokemon.Any(e => e.CatchedPokemon_Id == id);
		}
	}
}
