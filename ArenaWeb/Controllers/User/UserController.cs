using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArenaWeb.Controllers.User
{
    public class UserController : Controller
    {
        [HttpGet("~/account")]
        public IActionResult SignIn() => View("Account");

        [HttpGet("~/UserDex")]
        public IActionResult UserDex() => View("UserDex");
    }
}