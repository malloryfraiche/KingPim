using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Models;
using KingPim.Models.ViewModels;
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
        
        [HttpGet]
        public IActionResult GetCategoriesToJson()
        {
            var categories = _categoryRepo.GetAllCategories();
            return Json(categories);
        }
        
        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel vm)
        {
            _categoryRepo.AddCategory(vm);

            var url = Url.Action("Index", "Category");
            return Json(url);
        }

        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            var deletedCat = _categoryRepo.DeleteCategory(categoryId);
            if (deletedCat != null)
            {
                // error - category was found and not deleted for some reason.
            }
            else
            {
                // error - category was not found in DB.
            }
            return RedirectToAction(nameof(Index));
        }

    }
}