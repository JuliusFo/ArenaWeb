using ArenaWeb.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaWeb.Controllers.Home
{
	public class HomeController : Controller
	{
		#region Fields

		private readonly AppDbContext db;

		#endregion

		#region Constructor

		public HomeController(AppDbContext db)
		{
			this.db = db;
		}

		#endregion

		#region Properties



		#endregion

		#region Methods

		#region Web-API

		[HttpGet("~/")]
		public async Task<IActionResult> Index()
		{
			var userId = User.Claims.Where(c => c.Type.Contains("nameidentifier")).FirstOrDefault()?.Value;

			if (null == userId)
			{
				return View();
			}

			var dbUser = await db.Twitchuser.Where(u => u.Twitchuser_Id == userId).FirstOrDefaultAsync();

			if (null == dbUser || true)
			{
				return View("~/Views/Register/Index.cshtml");
			}
			else
			{
				return View();
			}
		}
	}

	#endregion

	#endregion
}