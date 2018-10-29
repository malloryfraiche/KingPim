using KingPim.Data.DataAccess;
using KingPim.Models;
using KingPim.Models.ViewModels;
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

        // CREATE and UPDATE product attribute.
        public void AddProductAttribute(AttributeGroupProductAttributeViewModel vm)
        {
            if (vm.Id == 0)     // Create
            {
                var productAttr = new ProductAttribute
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    Type = vm.Type,
                    AttributeGroupId = vm.AttributeGroupId
                };
                ctx.ProductAttributes.Add(productAttr);
            }
            else       // Update
            {

            }
            ctx.SaveChanges();
        }
    }
}
