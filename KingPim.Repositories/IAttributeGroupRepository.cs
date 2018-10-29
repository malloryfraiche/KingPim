using KingPim.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface IAttributeGroupRepository
    {
        IEnumerable<AttributeGroup> AttributeGroups { get; }

        IEnumerable<AttributeGroup> GetAllAttributeGroups();

        void AddAttributeGroup(AttributeGroupProductAttributeViewModel vm);
    }
}
