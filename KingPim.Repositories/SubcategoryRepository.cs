using KingPim.Data.DataAccess;
using KingPim.Models;
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
    }
}
