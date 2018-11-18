using KingPim.Data.DataAccess;
using KingPim.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        // CREATE and UPDATE subcategory.
        public void AddSubcategory(AddSubcategoryViewModel vm)
        {
            if (vm.Id == 0)     // Create
            {
                // If the Subcategory has any connecting Attribute Groups.
                if (vm.AttributeGroupId != null)
                {
                    var subcatAttrGroupList = new List<SubcategoryAttributeGroup>();
                    foreach (var attrGroupId in vm.AttributeGroupId)
                    {
                        var vmSubcatAttrGroup = new SubcategoryAttributeGroup
                        {
                            SubcategoryId = vm.Id,
                            AttributeGroupId = attrGroupId
                        };
                        subcatAttrGroupList.Add(vmSubcatAttrGroup);
                    }
                    var newSubcat = new Subcategory
                    {
                        Name = vm.Name,
                        CategoryId = vm.CategoryId,
                        Products = null,
                        SubcategoryAttributeGroups = subcatAttrGroupList,
                        AddedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        Published = false,
                        Version = 1,
                        ModifiedBy = vm.ModifiedBy
                    };
                    ctx.Subcategories.Add(newSubcat);
                }
                else
                {
                    // Otherwise will save SubcategoryAttributeGroups as null.
                    var newSubcat = new Subcategory
                    {
                        Name = vm.Name,
                        CategoryId = vm.CategoryId,
                        Products = null,
                        SubcategoryAttributeGroups = null,
                        AddedDate = DateTime.Now,
                        UpdatedDate = DateTime.Now,
                        Published = false,
                        Version = 1,
                        ModifiedBy = vm.ModifiedBy
                    };
                    ctx.Subcategories.Add(newSubcat);
                }
            }
            else     // Update
            {
                var ctxSubcategory = ctx.Subcategories.FirstOrDefault(x => x.Id.Equals(vm.Id));
                var ctxSubcatAttrGroups = ctx.SubcategoryAttributeGroups.Where(x => x.SubcategoryId == vm.Id);

                // Remove the subcat attribute group connection from DB first.
                ctx.SubcategoryAttributeGroups.RemoveRange(ctxSubcatAttrGroups);

                var subcatAttrGroupList = new List<SubcategoryAttributeGroup>();
                foreach (var attrGroupId in vm.AttributeGroupId)
                {
                    var vmSubcatAttrGroup = new SubcategoryAttributeGroup
                    {
                        SubcategoryId = vm.Id,
                        AttributeGroupId = attrGroupId
                    };
                    subcatAttrGroupList.Add(vmSubcatAttrGroup);
                }
                
                if (ctxSubcategory != null)
                {
                    ctxSubcategory.Name = vm.Name;
                    ctxSubcategory.CategoryId = vm.CategoryId;
                    ctxSubcategory.SubcategoryAttributeGroups = subcatAttrGroupList;
                    ctxSubcategory.UpdatedDate = DateTime.Now;
                    ctxSubcategory.Version = ctxSubcategory.Version + 1;
                    ctxSubcategory.ModifiedBy = vm.ModifiedBy;
                }
            }
            ctx.SaveChanges();
        }

        public Subcategory DeleteSubcategory(int subcategoryId)
        {
            var ctxSubcategory = ctx.Subcategories.FirstOrDefault(s => s.Id.Equals(subcategoryId));
            if (ctxSubcategory != null)
            {
                ctx.Subcategories.Remove(ctxSubcategory);
                // To also delete the SubcategoryAttributeGroup connection in DB table.
                var ctxSubcatAttrGroup = ctx.SubcategoryAttributeGroups.Where(x => x.SubcategoryId.Equals(subcategoryId));
                foreach (var subAttrGroup in ctxSubcatAttrGroup)
                {
                    ctx.SubcategoryAttributeGroups.Remove(subAttrGroup);
                }
                ctx.SaveChanges();
            }
            return ctxSubcategory;
        }

        public void PublishSubcategory(AddSubcategoryViewModel vm)
        {
            var ctxSubcategory = ctx.Subcategories.FirstOrDefault(x => x.Id.Equals(vm.Id));
            if (ctxSubcategory != null)
            {
                // The subcategories category.
                var ctxCategory = ctx.Categories.FirstOrDefault(x => x.Id.Equals(ctxSubcategory.CategoryId));
                if (!ctxSubcategory.Published)
                {
                    ctxSubcategory.Published = true;
                    ctxCategory.Published = true;
                }
                else
                {
                    ctxSubcategory.Published = false;

                    // If all the category subcategories have false (unpublished) for all subcats, then the category needs to also be false (unpublished).
                    if (ctxCategory.Subcategories.Count(x => x.Published) == 0)
                    {
                        ctxCategory.Published = false;
                    }
                }
                ctx.SaveChanges();

                // The products in the subcategory.
                var ctxProducts = ctx.Products.Where(p => p.SubcategoryId.Equals(vm.Id));
                foreach (var prod in ctxProducts)
                {
                    // If the subcategory is true (published), then all the subcategories products need to be true (published).
                    if (ctxSubcategory.Published)
                    {
                        prod.Published = true;
                    }
                    // If the subcategory is false (unpublished), then all the subcategories products need to be false (unpublished).
                    else
                    {
                        prod.Published = false;
                    }
                }
                ctx.SaveChanges();
            }
            
        }

        //public IEnumerable<Subcategory> Search(string searchString)
        //{
        //    IEnumerable<Subcategory> subcategories;

        //    // search logic here.

        //    return subcategories;
        //}
    }
}
