using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            // Have the whole King Pim site access here...
            return View();
        }

        public IActionResult Login()
        {
            return RedirectToAction(nameof(Index));
        }
    }
}