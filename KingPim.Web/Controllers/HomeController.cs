using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Infrastructure.Helpers;
using KingPim.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepo;
        private ISubcategoryRepository _subcategoryRepo;
        private ICategoryRepository _categoryRepo;
        private ISearchRepository _searchRepo;

        public HomeController(IProductRepository productRepo, ISubcategoryRepository subcategoryRepo, ICategoryRepository categoryRepo, ISearchRepository searchRepo)
        {
            _productRepo = productRepo;
            _subcategoryRepo = subcategoryRepo;
            _categoryRepo = categoryRepo;
            _searchRepo = searchRepo;
        }

        public IActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetCategoriesToJson()
        {
            var categories = _categoryRepo.GetAllCategories();
            var getCategories = ViewModelHelper.GetCategories(categories);
            return Json(getCategories);
        }

        [HttpGet]
        [Produces("application/xml")]
        public IActionResult GetCategoriesToXml()
        {
            var categories = _categoryRepo.GetAllCategories();
            var getCategories = ViewModelHelper.GetCategories(categories);
            return Ok(getCategories);
        }


        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetSubcategoriesToJson()
        {
            var subcategories = _subcategoryRepo.Subcategories;
            var getSubcategories = ViewModelHelper.GetSubcategories(subcategories);
            return Json(getSubcategories);
        }

        [HttpGet]
        [Produces("application/xml")]
        public IActionResult GetSubcategoriesToXml()
        {
            var subcategories = _subcategoryRepo.Subcategories;
            var getSubcategories = ViewModelHelper.GetSubcategories(subcategories);
            return Ok(getSubcategories);
        }
        
    }
}