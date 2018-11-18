using KingPim.Data.DataAccess;
using KingPim.Models;
using KingPim.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

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
                if (vm.PredefinedListName != null)
                {
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
                else
                {
                    // No predefined list selected so just save the ProductAttribute like normal.
                    var productAttr = new ProductAttribute
                    {
                        Name = vm.Name,
                        Description = vm.Description,
                        Type = vm.Type,
                        AttributeGroupId = vm.AttributeGroupId
                    };
                    ctx.ProductAttributes.Add(productAttr);
                }
            }
            else       // Update
            {
                // First: if there is data for the PredefinedList db table find it and remove it.
                // If there is any info entered from the user here, save it.
                var ctxPredefinedList = ctx.PredefinedLists.FirstOrDefault(pl => pl.Name.Equals(vm.PredefinedListName));
                if (ctxPredefinedList != null)
                {
                    ctx.PredefinedLists.Remove(ctxPredefinedList);
                    ctx.SaveChanges();

                    if (vm.PredefinedListName != null)
                    {
                        var preDefinedList = new PredefinedList
                        {
                            Name = vm.PredefinedListName
                        };
                        ctx.PredefinedLists.Add(preDefinedList);
                        ctx.SaveChanges();
                    }
                    // Second: if there is data for the PredefinedListOptions db table, remove it.
                    // If there is any info entered from the user here, save it.
                    var ctxPredefinedListOptions = ctx.PredefinedListOptions;
                    var recentlySavedPredefinedList = ctx.PredefinedLists.FirstOrDefault(pl => pl.Name.Equals(vm.PredefinedListName));
                    if (recentlySavedPredefinedList != null)
                    {
                        foreach (var option in ctxPredefinedListOptions)
                        {
                            if (recentlySavedPredefinedList.Id == option.PredefinedListId)
                            {
                                ctx.PredefinedListOptions.Remove(option);
                                ctx.SaveChanges();
                            }
                        }
                        foreach (var vmOption in vm.PredefinedListOptionNames)
                        {
                            var predefinedListOption = new PredefinedListOption
                            {
                                Name = vmOption,
                                PredefinedListId = recentlySavedPredefinedList.Id
                            };
                            ctx.PredefinedListOptions.Add(predefinedListOption);
                            ctx.SaveChanges();
                        }
                        // Third: update the data in the ProductAttribute db table.
                        var ctxProductAttr = ctx.ProductAttributes.FirstOrDefault(pa => pa.Id.Equals(vm.Id));
                        if (ctxProductAttr != null)
                        {
                            ctxProductAttr.Name = vm.Name;
                            ctxProductAttr.Type = vm.Type;
                            ctxProductAttr.Description = vm.Description;
                            ctxProductAttr.AttributeGroupId = vm.AttributeGroupId;
                            ctxProductAttr.PredefinedListId = recentlySavedPredefinedList.Id;
                        }
                    }
                }
                else
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
                
            }
            ctx.SaveChanges();
        }
        public ProductAttribute DeleteProductAttribute(int productAttrId)
        {
            var ctxProductAttr = ctx.ProductAttributes.FirstOrDefault(pa => pa.Id.Equals(productAttrId));
            var ctxPredefinedList = ctx.PredefinedLists.FirstOrDefault(pl => pl.Id.Equals(ctxProductAttr.PredefinedListId));
            var ctxPredefinedListOptions = ctx.PredefinedListOptions;
            // Delete the ProductAttributes connection to PredefinedListOptions.
            if (ctxPredefinedList != null)
            {
                foreach (var option in ctxPredefinedListOptions)
                {
                    if (ctxPredefinedList.Id == option.PredefinedListId)
                    {
                        ctx.PredefinedListOptions.Remove(option);
                    }
                }
            }
            // Delete the ProductAttributes connection to PredefinedList.
            if (ctxPredefinedList != null)
            {
                ctx.PredefinedLists.Remove(ctxPredefinedList);
            }
            // Delete the ProductAttribute.
            if (ctxProductAttr != null)
            {
                ctx.ProductAttributes.Remove(ctxProductAttr);
            }
            ctx.SaveChanges();
            return ctxProductAttr;
        }
    }
}