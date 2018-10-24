using KingPim.Data.DataAccess;
using KingPim.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        // Injecting DB connection to SubcategoryRepository (DI)..
        public ApplicationDbContext ctx;
        public SubcategoryRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        public IEnumerable<Subcategory> Subcategories => ctx.Subcategories;


        public IEnumerable<Subcategory> GetAllSubcategories()
        {
            return Subcategories;
        }

        public void AddSubcategory(AddSubcategoryViewModel vm)
        {
            if (vm.Id == 0)
            {
                var newSubcat = new Subcategory
                {
                    Name = vm.Name,
                    CategoryId = vm.CategoryId,
                    Products = null,
                    AttributeGroups = null,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                    Version = 1
                };
                ctx.Subcategories.Add(newSubcat);
            }
            ctx.SaveChanges();
        }
    }
}
