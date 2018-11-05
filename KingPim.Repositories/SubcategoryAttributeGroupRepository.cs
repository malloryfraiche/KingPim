using KingPim.Data.DataAccess;
using KingPim.Models;
using System;
using System.Collections.Generic;
using System.Text;

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
