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
        public IViewComponentResult Invoke()
        {
            var catVm = new AddCategoryViewModel();

            return View(catVm);
        }
    }
}
