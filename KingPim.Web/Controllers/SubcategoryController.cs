using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    public class SubcategoryController : Controller
    {
        private ISubcategoryRepository _subcategoryRepo;
        public SubcategoryController(ISubcategoryRepository subcategoryRepo)
        {
            _subcategoryRepo = subcategoryRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var subcategories = _subcategoryRepo.GetAllSubcategories();
            ViewBag.Title = "Subcategory";
            ViewBag.TitlePlural = "Subcategories";

            return View(subcategories);
        }
    }
}