using KingPim.Data.DataAccess;
using KingPim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public class ProductAttributeValueRepository : IProductAttributeValueRepository
    {
        private ApplicationDbContext ctx;
        public ProductAttributeValueRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        public IEnumerable<ProductAttributeValue> ProductAttributeValues => ctx.ProductAttributeValues;

        public IEnumerable<ProductAttributeValue> GetAllProductAttributeValues()
        {
            return ProductAttributeValues;
        }

    }
}
