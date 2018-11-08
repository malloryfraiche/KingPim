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
                        Version = 1
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
                        Version = 1
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
                ctx.SaveChanges();
            }
            return ctxSubcategory;
        }

        public void PublishSubcategory(AddSubcategoryViewModel vm)
        {
            var ctxSubcategory = ctx.Subcategories.FirstOrDefault(x => x.Id.Equals(vm.Id));

            if (ctxSubcategory != null)
            {
                var ctxCategory = ctx.Categories.FirstOrDefault(x => x.Id.Equals(ctxSubcategory.CategoryId));
                if (!ctxSubcategory.Published)
                {
                    ctxSubcategory.Published = true;
                    ctxCategory.Published = true;
                }
                else
                {
                    ctxSubcategory.Published = false;
                    if (ctxCategory.Subcategories.Count(x => x.Published) == 0)
                    {
                        ctxCategory.Published = false;
                    }
                }
            }
            ctx.SaveChanges();
        }
    }
}
