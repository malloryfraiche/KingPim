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
                var attrGroup = new AttributeGroup
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    SubcategoryId = vm.SubcategoryId,
                    ProductAttributes = null
                };
                ctx.AttributeGroups.Add(attrGroup);
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
    }
}
