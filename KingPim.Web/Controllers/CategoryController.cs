using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Models;
using KingPim.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepo;
        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        
        [HttpGet]
        public IActionResult Index()
        {
            var categories = _categoryRepo.GetAllCategories();
            ViewBag.Title = "Category";
            ViewBag.TitlePlural = "Categories";

            return View(categories);
        }

        [HttpPost]
        public IActionResult AddNewCategory(Category category)
        {
            _categoryRepo.SaveCategory(category);

            return View("Index", category);
        }

    }
}