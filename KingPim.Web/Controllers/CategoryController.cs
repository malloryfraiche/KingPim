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
            vm.ModifiedBy = User.Identity.Name;
            _categoryRepo.AddCategory(vm);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult EditCategory(AddCategoryViewModel vm)
        {
            vm.ModifiedBy = User.Identity.Name;
            _categoryRepo.AddCategory(vm);
            var url = Url.Action("Index", "Category");
            return Json(url);
        }
        [HttpPost]
        public IActionResult DeleteCategory(int categoryId)
        {
            var deletedCat = _categoryRepo.DeleteCategory(categoryId);
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
        public IActionResult GetCategoriesToJsonExport(int categoryId)
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
            var categories = _categoryRepo.Categories;
            var getCategories = ViewModelHelper.GetCategories(categories);
            var selectedCategory = getCategories.FirstOrDefault(x => x.Id.Equals(categoryId));
            if (categoryId == 0)
            {
                return Ok(getCategories);
            }
            else
            {
                return Ok(selectedCategory);
            }
        }
    }
}