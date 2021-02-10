using ArenaWeb.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaWeb.Controllers.Privacy
{
	public class PrivacyController : Controller
	{
		#region Fields

		private readonly AppDbContext db;

		#endregion

		#region Constructor

		public PrivacyController(AppDbContext db)
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
			return View();
		}

		#endregion

		#endregion
	}
}
