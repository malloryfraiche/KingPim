using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class SubcategoryController : Controller
    {
        private ISubcategoryRepository _subcategoryRepo;
        private ISubcategoryAttributeGroupRepository _subcatAttributeGroupRepo;
        public SubcategoryController(ISubcategoryRepository subcategoryRepo, ISubcategoryAttributeGroupRepository subcategoryAttributeGroupRepo)
        {
            _subcategoryRepo = subcategoryRepo;
            _subcatAttributeGroupRepo = subcategoryAttributeGroupRepo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var subcategories = _subcategoryRepo.GetAllSubcategories();
            ViewBag.Title = "Subcategory";
            ViewBag.TitlePlural = "Subcategories";

            return View(subcategories);
        }

        [HttpGet]
        public IActionResult GetSubcategoriesToJson()    // To ajax fill dropdown lists in modals with data..
        {
            var subcategories = _subcategoryRepo.GetAllSubcategories();
            return Json(subcategories);
        }

        [HttpGet]
        public IActionResult GetSubcategoryAttributeGroupsToJson()  // To ajax fill the dropdown list in edit modals with data..
        {
            var subcatAttrGroups = _subcatAttributeGroupRepo.SubcategoryAttributeGroups;
            return Json(subcatAttrGroups);
        }

        [HttpPost]
        public IActionResult AddSubcategory(AddSubcategoryViewModel vm)
        {
            _subcategoryRepo.AddSubcategory(vm);
            var url = Url.Action("Index", "Subcategory");
            return Json(url);
        }
        
        [HttpPost]
        public IActionResult DeleteSubcategory(int subcategoryId)
        {
            var deletedSubcat = _subcategoryRepo.DeleteSubcategory(subcategoryId);
            if (deletedSubcat != null)
            {
                // error - subcategory was found and not deleted for some reason.
            }
            else
            {
                // error - subcategory was not found in DB.
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult PublishSubcategory(AddSubcategoryViewModel vm)
        {
            _subcategoryRepo.PublishSubcategory(vm);
            return RedirectToAction(nameof(Index));
        }
    }
}