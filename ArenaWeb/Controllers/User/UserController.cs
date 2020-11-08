using ArenaWeb.Data;
using ArenaWeb.Transfer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaWeb.Controllers.User
{
	public class UserController : Controller
	{
		#region Fields

		private readonly AppDbContext db;

		#endregion

		#region Constructor

		public UserController(AppDbContext db)
		{
			this.db = db;
		}

		#endregion

		#region Properties



		#endregion

		#region Methods

		#region Web-API

		public async Task<IActionResult> Index()
		{
			var userId = User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault()?.Value;
			var query = db.Twitchuser.Where(u => u.Twitchuser_Id == userId);
			var queryResult = await query.Select(r => new TransferUserElement()
			{
				UserName = r.DisplayName,
				RegisterDt = DateTime.Now,
				TotalPokemonCatched = r.CatchedPokemon.Sum(c => c.Pokemon_AmountCatched),
				TotalUniquePokemonCatched = r.CatchedPokemon.Count(),
				TotalAchievementsUnlocked = r.Achievements.Count(),
				TotalAchievementsDone = r.Achievements.Where(a => a.LastFight != null).Count(),
				StarterPokemon = "Platzhalter"
			}).FirstOrDefaultAsync();

			return View(queryResult);
		}

		#endregion

		#endregion
	}
}