using KingPim.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Infrastructure.Helpers
{
    public static class ViewModelHelper
    {
        // Get categories to XML or JSON
        public static List<CategoryViewModel> GetCategories(IEnumerable<Category> categories)
        {
            var categoriesVm = new List<CategoryViewModel>();
            foreach (var cat in categories)
            {
                categoriesVm.Add(new CategoryViewModel
                {
                    Id = cat.Id,
                    Name = cat.Name,
                    Subcategories = ConvertToListOfSubcatVms(cat.Subcategories)

                });
            }
            return categoriesVm;
        }

        private static List<SubcategoryViewModel> ConvertToListOfSubcatVms(List<Subcategory> subcategories)
        {
            var subcatList = new List<SubcategoryViewModel>();
            foreach (var subcat in subcategories)
            {
                subcatList.Add(new SubcategoryViewModel
                {
                    Id = subcat.Id,
                    Name = subcat.Name
                });
            }
            return subcatList;
        }
    }
}