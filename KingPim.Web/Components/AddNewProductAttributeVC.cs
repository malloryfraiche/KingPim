using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Components
{
    public class AddNewProductAttributeVC : ViewComponent
    {
        private IAttributeGroupRepository _attrGroupRepo;
        public AddNewProductAttributeVC(IAttributeGroupRepository attributeGroupRepository)
        {
            _attrGroupRepo = attributeGroupRepository;
        }
        public IViewComponentResult Invoke()
        {
            var attrGroup = _attrGroupRepo.AttributeGroups;
            var attrVm = new AttributeGroupProductAttributeViewModel
            {
                AttributeGroup = attrGroup
            };
            return View(attrVm);
        }
    }
}