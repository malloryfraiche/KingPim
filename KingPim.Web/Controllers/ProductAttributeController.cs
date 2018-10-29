using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    public class ProductAttributeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.TitlePlural = "Product Attributes";
            ViewBag.Title = "Product Attribute";
            return View();
        }
    }
}