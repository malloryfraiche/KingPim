using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Components
{
    public class AddNewSubcategoryVC : ViewComponent
    {
        private ICategoryRepository _categoryRepo;
        private IAttributeGroupRepository _attrGroupRepo;

        private ISubcategoryAttributeGroupRepository _subcatAttrGroupRepo;

        public AddNewSubcategoryVC(ICategoryRepository categoryRepo, IAttributeGroupRepository attributeGroupRepo, ISubcategoryAttributeGroupRepository subcategoryAttributeGroupRepo)
        {
            _categoryRepo = categoryRepo;
            _attrGroupRepo = attributeGroupRepo;

            _subcatAttrGroupRepo = subcategoryAttributeGroupRepo;
        }

        public IViewComponentResult Invoke()
        {
            var category = _categoryRepo.Categories;
            var attrGroup = _attrGroupRepo.AttributeGroups;

            var subcatVm = new AddSubcategoryViewModel
            {
                Category = category,
                AttributeGroups = attrGroup
            };

            return View(subcatVm);
        }
    }
}
