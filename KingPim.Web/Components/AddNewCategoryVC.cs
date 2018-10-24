using KingPim.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Components
{
    public class AddNewCategoryVC : ViewComponent
    {
        private ICategoryRepository _categoryRepo;
        public AddNewCategoryVC(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IViewComponentResult Invoke()
        {
            var test = new AddCategoryViewModel();

            return View(test);
        }
    }
}
