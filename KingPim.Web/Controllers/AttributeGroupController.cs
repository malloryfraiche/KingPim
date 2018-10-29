using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
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

        [HttpPost]
        public IActionResult AddAttributeGroup(AttributeGroupProductAttributeViewModel vm)
        {
            _attrGroupRepo.AddAttributeGroup(vm);
            return RedirectToAction(nameof(Index));
        }
    }
}