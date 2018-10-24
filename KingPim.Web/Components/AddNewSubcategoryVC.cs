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
        public IViewComponentResult Invoke()
        {
            var subcatVm = new AddSubcategoryViewModel();

            return View(subcatVm);
        }
    }
}
