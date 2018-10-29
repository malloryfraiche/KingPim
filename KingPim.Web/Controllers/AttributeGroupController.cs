using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public IActionResult Index()
        {
            var attrGroups = _attrGroupRepo.GetAllAttributeGroups();
            ViewBag.TitlePlural = "Attribute Groups";
            ViewBag.Title = "Attribute Group";
            return View(attrGroups);
        }
    }
}