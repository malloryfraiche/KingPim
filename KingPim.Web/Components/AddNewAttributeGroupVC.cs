using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Components
{
    public class AddNewAttributeGroupVC : ViewComponent
    {
        //private ISubcategoryRepository _subcatRepo;
        //public AddNewAttributeGroupVC(ISubcategoryRepository subcategoryRepository)
        //{
        //    _subcatRepo = subcategoryRepository;
        //}

        public IViewComponentResult Invoke()
        {
            //var subcategory = _subcatRepo.Subcategories;
            var attrVm = new AttributeGroupProductAttributeViewModel();
            //{
            //    Subcategory = subcategory
            //};

            return View(attrVm);
        }
    }
}
