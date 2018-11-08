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

        // CREATE and UPDATE category.
        public void AddCategory(AddCategoryViewModel vm)
        {
            if (vm.Id == 0)     // Create
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
            else     // Update
            {
                var ctxCategory = ctx.Categories.FirstOrDefault(x => x.Id.Equals(vm.Id));
                if (ctxCategory != null)
                {
                    ctxCategory.Name = vm.Name;
                    ctxCategory.UpdatedDate = DateTime.Now;
                    ctxCategory.Version = ctxCategory.Version + 1;
                }
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

        public void PublishCategory(AddCategoryViewModel vm)
        {

            var ctxCategory = ctx.Categories.FirstOrDefault(x => x.Id.Equals(vm.Id));
            if (ctxCategory != null)
            {
                if (!ctxCategory.Published)
                {
                    ctxCategory.Published = true;
                }
                else
                {
                    ctxCategory.Published = false;
                }
                ctx.SaveChanges();


                var ctxSubcats = ctx.Subcategories.Where(x => x.CategoryId.Equals(vm.Id));
                //var trueFalseValue = false;
                foreach (var subcat in ctxSubcats)
                {
                    if (ctxCategory.Published)
                    {
                        subcat.Published = true;
                    }
                    else
                    {
                        subcat.Published = false;
                    }

                }
                ctx.SaveChanges();
                //ctx.Subcategories.FirstOrDefault(x => x.);

            }
        }
    }
}
