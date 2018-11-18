using KingPim.Models;
using System.Collections.Generic;

namespace KingPim.Repositories
{
    public interface ISubcategoryAttributeGroupRepository
    {
        IEnumerable<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; }
    }
}