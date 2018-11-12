using KingPim.Data.DataAccess;
using KingPim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private ApplicationDbContext ctx;
        public SearchRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        public IEnumerable<Category> Categories => ctx.Categories;
        public IEnumerable<Subcategory> Subcategories => ctx.Subcategories;
        public IEnumerable<Product> Products => ctx.Products;


    }
}
