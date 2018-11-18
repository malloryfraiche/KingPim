using KingPim.Models;
using KingPim.Models.ViewModels;
using System.Collections.Generic;

namespace KingPim.Repositories
{
    public interface IAttributeGroupRepository
    {
        IEnumerable<AttributeGroup> AttributeGroups { get; }
        IEnumerable<AttributeGroup> GetAllAttributeGroups();
        void AddAttributeGroup(AttributeGroupProductAttributeViewModel vm);
        AttributeGroup DeleteAttributeGroup(int attrGroupId);
    }
}