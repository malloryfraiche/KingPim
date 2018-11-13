using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using KingPim.Infrastructure.Helpers;
using KingPim.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace KingPim.Web.Controllers
{
    [Authorize]
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
        public IActionResult GetCategoriesToJson()      // To ajax fill dropdown lists in modals with data..
        {
            var categories = _categoryRepo.GetAllCategories();
            return Json(categories);
        }
        
        [HttpPost]
        public IActionResult AddCategory(AddCategoryViewModel vm)
        {
            _categoryRepo.AddCategory(vm);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult EditCategory(AddCategoryViewModel vm)
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

        [HttpPost]
        public IActionResult PublishCategory(AddCategoryViewModel vm)
        {
            _categoryRepo.PublishCategory(vm);
            return RedirectToAction(nameof(Index));
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
            var categories = _categoryRepo.Categories;
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
    }
}