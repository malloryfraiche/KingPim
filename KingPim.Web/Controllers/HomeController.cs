using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using KingPim.Data.DataAccess;
using KingPim.Infrastructure.Helpers;
using KingPim.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace KingPim.Web.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepo;
        private ISubcategoryRepository _subcategoryRepo;
        private ICategoryRepository _categoryRepo;

        private ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context, IProductRepository productRepo, ISubcategoryRepository subcategoryRepo, ICategoryRepository categoryRepo, ISearchRepository searchRepo)
        {
            _productRepo = productRepo;
            _subcategoryRepo = subcategoryRepo;
            _categoryRepo = categoryRepo;
            _context = context;
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
            var selectedCategory = getCategories.FirstOrDefault(x => x.Id.Equals(categoryId));

            if (categoryId == 0)
            {
                var categoryJson = JsonConvert.SerializeObject(getCategories);
                var bytes = Encoding.UTF8.GetBytes(categoryJson);
                return File(bytes, "application/octet-stream", "categories.json");
            }
            else
            {
                var selectedCategoryJson = JsonConvert.SerializeObject(selectedCategory);
                var bytes = Encoding.UTF8.GetBytes(selectedCategoryJson);
                return File(bytes, "application/octet-stream", "category_" + categoryId + ".json");
            }
        }

        [HttpGet]
        [Produces("application/xml")]
        public IActionResult GetCategoriesToXml(int categoryId)
        {
            //var categories = _categoryRepo.GetAllCategories();
            var categories = _context.Categories;
            var getCategories = ViewModelHelper.GetCategories(categories);
            var selectedCategory = getCategories.FirstOrDefault(x => x.Id.Equals(categoryId));

            if (categoryId == 0)
            {
                //var categoryJson = JsonConvert.SerializeObject(getCategories);
                //var bytes = Encoding.UTF8.GetBytes(categoryJson);
                string returnString = null;
                XmlSerializer categoryXml = new XmlSerializer(typeof(CategoryViewModel));
                var settings = new XmlWriterSettings
                {
                    Indent = true,
                    NewLineOnAttributes = true,
                    Encoding = Encoding.UTF8
                };

                using (StringWriter sw = new StringWriter())
                {
                    using (var textWriter = XmlWriter.Create(sw, settings))
                    {
                        categoryXml.Serialize(textWriter, getCategories);
                    }
                    sw.Flush();
                    returnString = sw.ToString();
                }
                
                var bytes = Encoding.UTF8.GetBytes(returnString);
                
                //XmlDocument doc = new XmlDocument();
                //XmlElement root = doc.CreateElement("root");
                //XmlElement element = doc.CreateElement("child");
                //root.AppendChild(element);
                //doc.AppendChild(root);

                //MemoryStream ms = new MemoryStream();
                //doc.Save(ms);
                //byte[] bytes = ms.ToArray();

                return File(bytes, "application/octet-stream", "categories.xml");
            }
            else
            {
                var categoryJson = JsonConvert.SerializeObject(selectedCategory);
                var bytes = Encoding.UTF8.GetBytes(categoryJson);
                return File(bytes, "application/octet-stream", "category_" + categoryId + ".xml");
            }
        }

        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetSubcategoriesToJson(int subcategoryId)
        {
            var subcategories = _subcategoryRepo.Subcategories;
            var getSubcategories = ViewModelHelper.GetSubcategories(subcategories);
            var selectedSubcategory = getSubcategories.FirstOrDefault(x => x.Id.Equals(subcategoryId));

            if (subcategoryId == 0)
            {
                var subcategoryJson = JsonConvert.SerializeObject(getSubcategories);
                var bytes = Encoding.UTF8.GetBytes(subcategoryJson);
                return File(bytes, "application/octet-stream", "subcategories.json");
            }
            else
            {
                var selectedSubcategoryJson = JsonConvert.SerializeObject(selectedSubcategory);
                var bytes = Encoding.UTF8.GetBytes(selectedSubcategoryJson);
                return File(bytes, "application/octet-stream", "subcategory_" + subcategoryId + ".json");
            }
        }

        [HttpGet]
        [Produces("application/xml")]
        public IActionResult GetSubcategoriesToXml(int subcategoryId)
        {
            var subcategories = _subcategoryRepo.Subcategories;
            var getSubcategories = ViewModelHelper.GetSubcategories(subcategories);
            var selectedSubcategory = getSubcategories.FirstOrDefault(x => x.Id.Equals(subcategoryId));

            if (subcategoryId == 0)
            {
                return Ok(getSubcategories);
            }
            else
            {
                return Ok(selectedSubcategory);
            }
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