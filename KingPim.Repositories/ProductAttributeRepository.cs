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
        public IEnumerable<PredefinedListOption> PredefinedListOptions => ctx.PredefinedListOptions;


        public IEnumerable<ProductAttribute> GetAllProductAttributes()
        {
            return ProductAttributes;
        }

        // CREATE and UPDATE product attribute.
        public void AddProductAttribute(AttributeGroupProductAttributeViewModel vm)
        {
            if (vm.Id == 0)     // Create
            {
                // First: saving the data to the PredefinedList db table.
                var predefinedList = new PredefinedList
                {
                    Name = vm.PredefinedListName
                };
                ctx.PredefinedLists.Add(predefinedList);
                ctx.SaveChanges();

                var recentlySavedPredefinedListName = ctx.PredefinedLists.FirstOrDefault(pl => pl.Name.Equals(vm.PredefinedListName));

                // Second: saving the data to the PredefinedListOption db table.
                foreach (var option in vm.PredefinedListOptionNames)
                {
                    var predefinedListOption = new PredefinedListOption
                    {
                        Name = option,
                        PredefinedListId = recentlySavedPredefinedListName.Id
                    };
                    ctx.PredefinedListOptions.Add(predefinedListOption);
                    ctx.SaveChanges();
                }

                // Third: saving all data to the ProductAttribute db table with the above info.
                var productAttr = new ProductAttribute
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    Type = vm.Type,
                    AttributeGroupId = vm.AttributeGroupId,
                    PredefinedListId = recentlySavedPredefinedListName.Id
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

        public ProductAttribute DeleteProductAttribute(int productAttrId)
        {
            var ctxProductAttr = ctx.ProductAttributes.FirstOrDefault(pa => pa.Id.Equals(productAttrId));
            if (ctxProductAttr != null)
            {
                ctx.ProductAttributes.Remove(ctxProductAttr);
                ctx.SaveChanges();
            }
            return ctxProductAttr;
        }

    }
}
