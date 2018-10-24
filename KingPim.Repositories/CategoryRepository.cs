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
            var ctxCategory = ctx.Categories.FirstOrDefault();
            if (ctxCategory.Id == 0)
            {
                ctxCategory.Id = vm.Id;
                ctxCategory.Name = vm.Name;
                ctxCategory.AddedDate = vm.AddedDate;
                ctxCategory.Published = vm.Published;
                ctxCategory.Version = vm.Version;
            }
            ctx.SaveChanges();
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
