using KingPim.Data.DataAccess;
using KingPim.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPim.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        // Injecting DB connection to CategoryRepository (DI)..
        public ApplicationDbContext ctx;
        public CategoryRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        public IEnumerable<Category> Categories => ctx.Categories;


        public IEnumerable<Category> GetAllCategories()
        {
            return Categories;
        }
        

        public void AddCategory(AddCategoryViewModel vm)
        {
            if (vm.Id == 0)
            {
                var newCat = new Category
                {
                    Name = vm.Name,
                    Subcategories = null,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                    Version = 1
                };
                ctx.Categories.Add(newCat);
            }
            ctx.SaveChanges();
        }
        

        public Category DeleteCategory(int categoryId)
        {
            var ctxCategory = ctx.Categories.FirstOrDefault(c => c.Id.Equals(categoryId));
            if (ctxCategory != null)
            {
                ctx.Categories.Remove(ctxCategory);
                ctx.SaveChanges();
            }
            return ctxCategory;
        }




        //// To Create or Update a Category in DB.
        //public void SaveCategory(Category cat)
        //{
        //    if (cat.Id == 0)   // Create
        //    {
        //        ctx.Categories.Add(cat);
        //    }
        //    //else    // Update
        //    //{
        //    //    var dbCategory = ctx.Categories.FirstOrDefault(x => x.Id == cat.Id);
        //    //    if (dbCategory != null)
        //    //    {

        //    //    }

        //    //}

        //    ctx.SaveChanges();
        //}

    }
}
