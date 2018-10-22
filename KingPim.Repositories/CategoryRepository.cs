using KingPim.Data.DataAccess;
using KingPim.Models;
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
        
        // To Create or Update a Category in DB.
        public void SaveCategory(Category category)
        {
            if (category.Id == 0)   // Create
            {
                ctx.Categories.Add(category);
            }
            //else    // Update
            //{
            //    var dbCategory = ctx.Categories.FirstOrDefault(x => x.Id == category.Id);
            //    if (dbCategory != null)
            //    {

            //    }

            //}

            ctx.SaveChanges();
        }

    }
}
