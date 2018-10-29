using KingPim.Data.DataAccess;
using KingPim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public class ProductAttributeRepository : IProductAttributeRepository
    {
        public ApplicationDbContext ctx;
        public ProductAttributeRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        public IEnumerable<ProductAttribute> ProductAttributes => ctx.ProductAttributes;


        public IEnumerable<ProductAttribute> GetAllProductAttributes()
        {
            return ProductAttributes;
        }
    }
}
