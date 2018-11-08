using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository _productRepo;
        private ISubcategoryRepository _subcatRepo;
        public ProductController(IProductRepository productRepository, ISubcategoryRepository subcategoryRepo)
        {
            _productRepo = productRepository;
            _subcatRepo = subcategoryRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Title = "Product";
            ViewBag.TitlePlural = "Products";
            var products = _productRepo.GetAllProducts();
            var subcats = _subcatRepo.Subcategories;
            var vm = new ProductViewModel
            {
                Products = products,
                Subcategory = subcats
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel vm)
        {
            _productRepo.AddProduct(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult DeleteProduct(int productId)
        {
            _productRepo.DeleteProduct(productId);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult PublishProduct(ProductViewModel vm)
        {
            _productRepo.PublishProduct(vm);
            return RedirectToAction(nameof(Index));
        }
    }
}