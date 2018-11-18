using KingPim.Data.DataAccess;
using KingPim.Models;
using System.Collections.Generic;

namespace KingPim.Repositories
{
    public class SubcategoryAttributeGroupRepository : ISubcategoryAttributeGroupRepository
    {
        private ApplicationDbContext ctx;
        public SubcategoryAttributeGroupRepository(ApplicationDbContext context)
        {
            ctx = context;
        }
        public IEnumerable<SubcategoryAttributeGroup> SubcategoryAttributeGroups => ctx.SubcategoryAttributeGroups;
    }
}