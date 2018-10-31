using KingPim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface IProductAttributeValueRepository
    {
        IEnumerable<ProductAttributeValue> ProductAttributeValues { get; }

        IEnumerable<ProductAttributeValue> GetAllProductAttributeValues();
    }
}
