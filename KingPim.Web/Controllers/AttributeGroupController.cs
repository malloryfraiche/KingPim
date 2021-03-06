﻿using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class AttributeGroupController : Controller
    {
        private IAttributeGroupRepository _attrGroupRepo;
        public AttributeGroupController(IAttributeGroupRepository attributeGroupRepository)
        {
            _attrGroupRepo = attributeGroupRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var attrGroups = _attrGroupRepo.GetAllAttributeGroups();
            ViewBag.TitlePlural = "Attribute Groups";
            ViewBag.Title = "Attribute Group";
            return View(attrGroups);
        }
        [HttpGet]
        public IActionResult GetAttributeGroupsToJson()     // To ajax fill dropdown lists in modals with data..
        {
            var attrGroups = _attrGroupRepo.GetAllAttributeGroups();
            return Json(attrGroups);
        }
        [HttpPost]
        public IActionResult AddAttributeGroup(AttributeGroupProductAttributeViewModel vm)
        {
            _attrGroupRepo.AddAttributeGroup(vm);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult EditAttributeGroup(AttributeGroupProductAttributeViewModel vm)
        {
            _attrGroupRepo.AddAttributeGroup(vm);
            var url = Url.Action("Index", "AttributeGroup");
            return Json(url);
        }
        [HttpPost]
        public IActionResult DeleteAttributeGroup(int attrGroupId)
        {
            var deletedAttrGroup = _attrGroupRepo.DeleteAttributeGroup(attrGroupId);
            return RedirectToAction(nameof(Index));
        }
    }
}