using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Components
{
    public class AddNewProductVC : ViewComponent
    {
        private ISubcategoryRepository _subcatRepo;
        public AddNewProductVC(ISubcategoryRepository subcategoryRepo)
        {
            _subcatRepo = subcategoryRepo;
        }
        public IViewComponentResult Invoke()
        {
            var subcategories = _subcatRepo.Subcategories;
            var productVm = new ProductViewModel
            {
                Subcategory = subcategories
            };
            return View(productVm);
        }
    }
}