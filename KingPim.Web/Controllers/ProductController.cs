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
        public ProductController(IProductRepository productRepository)
        {
            _productRepo = productRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var products = _productRepo.GetAllProducts();
            ViewBag.Title = "Product";
            ViewBag.TitlePlural = "Products";
            return View(products);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductViewModel vm)
        {
            _productRepo.AddProduct(vm);
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