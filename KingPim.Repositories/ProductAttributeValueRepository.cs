using KingPim.Data.DataAccess;
using KingPim.Models;
using System.Collections.Generic;

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