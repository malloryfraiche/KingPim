using KingPim.Data.DataAccess;
using KingPim.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPim.Repositories
{
    public class AttributeGroupRepository : IAttributeGroupRepository
    {
        public ApplicationDbContext ctx;
        public AttributeGroupRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        public IEnumerable<AttributeGroup> AttributeGroups => ctx.AttributeGroups;

        public IEnumerable<AttributeGroup> GetAllAttributeGroups()
        {
            return AttributeGroups;
        }

        // CREATE and UPDATE attribute group.
        public void AddAttributeGroup(AttributeGroupProductAttributeViewModel vm)
        {
            if (vm.Id == 0)     // Create
            {
                
                var matchingAttributeGroupName = ctx.AttributeGroups.FirstOrDefault(x => x.Name.Contains(vm.Name));
                var theListOfProductAttributes = matchingAttributeGroupName.ProductAttributes;
                
                if (matchingAttributeGroupName != null)
                {
                    var attrGroup = new AttributeGroup
                    {
                        Name = vm.Name,
                        Description = vm.Description,
                        SubcategoryId = vm.SubcategoryId,
                        ProductAttributes = theListOfProductAttributes
                    };
                    ctx.AttributeGroups.Add(attrGroup);
                }
                else
                {
                    var attrGroup = new AttributeGroup
                    {
                        Name = vm.Name,
                        Description = vm.Description,
                        SubcategoryId = vm.SubcategoryId,
                        ProductAttributes = null
                    };
                    ctx.AttributeGroups.Add(attrGroup);
                }
                
            }
            else       // Update
            {
                var ctxAttributeGroup = ctx.AttributeGroups.FirstOrDefault(ag => ag.Id.Equals(vm.Id));
                if (ctxAttributeGroup != null)
                {
                    ctxAttributeGroup.Name = vm.Name;
                    ctxAttributeGroup.SubcategoryId = vm.SubcategoryId;
                    ctxAttributeGroup.Description = vm.Description;
                }
            }
            ctx.SaveChanges();
        }

        public AttributeGroup DeleteAttributeGroup(int attrGroupId)
        {
            var ctxAttrGroup = ctx.AttributeGroups.FirstOrDefault(ag => ag.Id.Equals(attrGroupId));
            if (ctxAttrGroup != null)
            {
                ctx.AttributeGroups.Remove(ctxAttrGroup);
                ctx.SaveChanges();
            }
            return ctxAttrGroup;
        }
    }
}
