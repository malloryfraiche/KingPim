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

        public HomeController(IProductRepository productRepo, ISubcategoryRepository subcategoryRepo, ICategoryRepository categoryRepo, ISearchRepository searchRepo)
        {
            _productRepo = productRepo;
            _subcategoryRepo = subcategoryRepo;
            _categoryRepo = categoryRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetCategoriesToJson(int categoryId)
        {
            var categories = _categoryRepo.GetAllCategories();
            var getCategories = ViewModelHelper.GetCategories(categories);

            if (categoryId == 0)
            {
                return Json(getCategories);
            }
            else
            {
                var selectedCategory = getCategories.FirstOrDefault(x => x.Id.Equals(categoryId));
                return Json(selectedCategory);
            }
        }

        [HttpGet]
        [Produces("application/xml")]
        public IActionResult GetCategoriesToXml(int categoryId)
        {
            var categories = _categoryRepo.GetAllCategories();
            var getCategories = ViewModelHelper.GetCategories(categories);

            if (categoryId == 0)
            {
                return Ok(getCategories);
            }
            else
            {
                var selectedCategory = getCategories.FirstOrDefault(x => x.Id.Equals(categoryId));
                return Ok(selectedCategory);
            }
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetSubcategoriesToJson(int subcategoryId)
        {
            var subcategories = _subcategoryRepo.Subcategories;
            var getSubcategories = ViewModelHelper.GetSubcategories(subcategories);

            if (subcategoryId == 0)
            {
                return Json(getSubcategories);
            }
            else
            {
                var selectedSubcategory = getSubcategories.FirstOrDefault(x => x.Id.Equals(subcategoryId));
                return Json(selectedSubcategory);
            }
        }

        [HttpGet]
        [Produces("application/xml")]
        public IActionResult GetSubcategoriesToXml(int subcategoryId)
        {
            var subcategories = _subcategoryRepo.Subcategories;
            var getSubcategories = ViewModelHelper.GetSubcategories(subcategories);

            if (subcategoryId == 0)
            {
                return Ok(getSubcategories);
            }
            else
            {
                var selectedSubcategory = getSubcategories.FirstOrDefault(x => x.Id.Equals(subcategoryId));
                return Ok(selectedSubcategory);
            }
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetProductsToJson(int productId)
        {
            var products = _productRepo.Products;
            var getProducts = ViewModelHelper.GetProducts(products);

            if (productId == 0)
            {
                return Json(getProducts);
            }
            else
            {
                var selectedProduct = getProducts.FirstOrDefault(x => x.Id.Equals(productId));
                return Json(selectedProduct);
            }
        }

        [HttpGet]
        [Produces("application/xml")]
        public IActionResult GetProductsToXml(int productId)
        {
            var products = _productRepo.Products;
            var getProducts = ViewModelHelper.GetProducts(products);

            if (productId == 0)
            {
                return Ok(getProducts);
            }
            else
            {
                var selectedProduct = getProducts.FirstOrDefault(x => x.Id.Equals(productId));
                return Ok(selectedProduct);
            }
        }
    }
}