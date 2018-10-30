using KingPim.Data.DataAccess;
using KingPim.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
                var ctxProductAttr = ctx.ProductAttributes.FirstOrDefault(pa => pa.Id.Equals(vm.Id));
                if (ctxProductAttr != null)
                {
                    ctxProductAttr.Name = vm.Name;
                    ctxProductAttr.Type = vm.Type;
                    ctxProductAttr.Description = vm.Description;
                    ctxProductAttr.AttributeGroupId = vm.AttributeGroupId;
                }
            }
            ctx.SaveChanges();
        }
    }
}
