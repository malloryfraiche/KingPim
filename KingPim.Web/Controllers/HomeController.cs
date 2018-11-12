using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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


        //[HttpPost]
        //public IActionResult Search(string searchString)
        //{
        //    ////var catSearchResults = _categoryRepo.Search(searchString);
        //    ////var subcatSearchResults = _subcategoryRepo.Search(catSearchResults);
        //    ////var searchResults = _productRepo

        //    return View("Index", searchResults);
        //}



        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetToJson()
        {
            var categories = _categoryRepo.GetAllCategories();
            return Json(categories);
        }

        [HttpGet]
        [Produces("application/xml")]
        public IActionResult GetToXml()
        {
            var categories = _categoryRepo.GetAllCategories();
            return Ok(categories);
        }

        [HttpGet("category/testgetjsonorxml/api/values.{format}"), FormatFilter]
        public IEnumerable<string> TestGetJsonOrXml()
        {
            var categories = _categoryRepo.GetAllCategories();

            return new string[] { categories.ToString() };
        }

    }


}