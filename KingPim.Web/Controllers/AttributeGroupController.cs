using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    public class AttributeGroupController : Controller
    {
        public IActionResult Index()
        {

            //ViewBag.Title = "";
            return View();
        }
    }
}