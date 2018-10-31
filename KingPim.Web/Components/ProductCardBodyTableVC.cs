using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Components
{
    public class ProductCardBodyTableVC : ViewComponent
    {
        // To have access to subcat data in the product card body table.
        private ISubcategoryRepository _subcatRepo;
        public ProductCardBodyTableVC(ISubcategoryRepository subcatRepository)
        {
            _subcatRepo = subcatRepository;
        }

        public IViewComponentResult Invoke()
        {
            var prodAttrValVM = new ProductAttributeValueViewModel
            {
                Subcategory = _subcatRepo.GetAllSubcategories()
            };
            return View(prodAttrValVM);
        }
    }
}
