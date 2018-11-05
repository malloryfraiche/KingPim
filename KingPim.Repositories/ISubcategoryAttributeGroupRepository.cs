using KingPim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface ISubcategoryAttributeGroupRepository
    {
        IEnumerable<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; }


    }
}
