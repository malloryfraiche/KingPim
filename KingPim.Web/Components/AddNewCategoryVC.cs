using KingPim.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Components
{
    public class AddNewCategoryVC : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var catVm = new AddCategoryViewModel();
            return View(catVm);
        }
    }
}