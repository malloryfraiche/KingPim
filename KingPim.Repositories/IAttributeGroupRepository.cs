using KingPim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface IAttributeGroupRepository
    {
        IEnumerable<AttributeGroup> AttributeGroups { get; }

        IEnumerable<AttributeGroup> GetAllAttributeGroups();
    }
}
