using KingPim.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Components
{
    public class AddNewAttributeGroupVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var attrVm = new AttributeGroupProductAttributeViewModel();
            return View(attrVm);
        }
    }
}