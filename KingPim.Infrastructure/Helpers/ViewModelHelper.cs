using KingPim.Models;
using KingPim.Models.ViewModels;
using KingPim.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Infrastructure.Helpers
{
    public static class ViewModelHelper
    {
        //private ICategoryRepository _categoryRepo;
        //public ViewModelHelper(ICategoryRepository categoryRepo)
        //{
        //    _categoryRepo = categoryRepo;
        //}
        
        // Get categories to XML or JSON.
        public static List<CategoryViewModel> GetCategories(IEnumerable<Category> categories)
        {
            //if (categoryId != 0)
            //{
            //    foreach(var cat in categories)
            //    {
            //        var selectedCategory = cat.Id.Equals(categoryId);
            //    }
            //}
            //else
            //{}
                var categoriesVm = new List<CategoryViewModel>();
                foreach (var cat in categories)
                {
                    categoriesVm.Add(new CategoryViewModel
                    {
                        Id = cat.Id,
                        Name = cat.Name,
                        Subcategories = ConvertToListOfSubcatVms(cat.Subcategories),
                        AddedDate = cat.AddedDate,
                        UpdatedDate = cat.UpdatedDate,
                        Published = cat.Published,
                        Version = cat.Version

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
                    Name = subcat.Name,
                    AddedDate = subcat.AddedDate,
                    UpdatedDate = subcat.UpdatedDate,
                    Version = subcat.Version,
                    Published = subcat.Published
                    // can have a list of products here too if neccessary..
                });
            }
            return subcatList;
        }

        // Get subcategories to XML and JSON.
        public static List<SubcategoryViewModel> GetSubcategories(IEnumerable<Subcategory> subcategories)
        {
            var subcategoriesVm = new List<SubcategoryViewModel>();
            foreach (var subcat in subcategories)
            {
                subcategoriesVm.Add(new SubcategoryViewModel
                {
                    Id = subcat.Id,
                    Name = subcat.Name,
                    Products = ConvertToListOfProductVms(subcat.Products),
                    AddedDate = subcat.AddedDate,
                    UpdatedDate = subcat.UpdatedDate,
                    Published = subcat.Published,
                    Version = subcat.Version
                });
            }

            return subcategoriesVm;
        }

        private static List<ProductViewModel> ConvertToListOfProductVms(List<Product> products)
        {
            var productList = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productList.Add(new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    AddedDate = product.AddedDate,
                    UpdatedDate = product.UpdatedDate,
                    Version = product.Version,
                    Published = product.Published
                });
            }
            return productList;
        }

        // Get products to XML and JSON.
        public static List<ProductViewModel> GetProducts(IEnumerable<Product> products)
        {
            var productVm = new List<ProductViewModel>();
            foreach (var product in products)
            {
                productVm.Add(new ProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    Description = product.Description,
                    AddedDate = product.AddedDate,
                    UpdatedDate = product.UpdatedDate,
                    Version = product.Version,
                    Published = product.Published
                });
            }
            return productVm;
        }
    }
}