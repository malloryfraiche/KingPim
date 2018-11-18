using System.Linq;
using System.Text;
using KingPim.Infrastructure.Helpers;
using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KingPim.Web.Controllers
{
    [Authorize]
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
            vm.ModifiedBy = User.Identity.Name;
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
        [HttpPost]
        public IActionResult SaveProductAttributeValue(ProductAttributeValueViewModel vm)
        {
            _productRepo.SaveProductAttributeValue(vm);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetProductsToJson(int productId)
        {
            var products = _productRepo.Products;
            var getProducts = ViewModelHelper.GetProducts(products);
            var selectedProduct = getProducts.FirstOrDefault(x => x.Id.Equals(productId));

            if (productId == 0)
            {
                var productJson = JsonConvert.SerializeObject(getProducts);
                var bytes = Encoding.UTF8.GetBytes(productJson);
                return File(bytes, "application/octet-stream", "products.json");
            }
            else
            {
                var selectedProductJson = JsonConvert.SerializeObject(selectedProduct);
                var bytes = Encoding.UTF8.GetBytes(selectedProductJson);
                return File(bytes, "application/octet-stream", "product_" + productId + ".json");
            }
        }
        [HttpGet]
        [Produces("application/xml")]
        public IActionResult GetProductsToXml(int productId)
        {
            var products = _productRepo.Products;
            var getProducts = ViewModelHelper.GetProducts(products);
            var selectedProduct = getProducts.FirstOrDefault(x => x.Id.Equals(productId));

            if (productId == 0)
            {
                return Ok(getProducts);
            }
            else
            {
                return Ok(selectedProduct);
            }
        }
    }
}