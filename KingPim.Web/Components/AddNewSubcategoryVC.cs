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
        public AddNewSubcategoryVC(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IViewComponentResult Invoke()
        {
            var category = _categoryRepo.Categories;
            var subcatVm = new AddSubcategoryViewModel
            {
                Category = category
            };

            return View(subcatVm);
        }
    }
}
