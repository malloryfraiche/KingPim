using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
