using KingPim.Models;
using System.Collections.Generic;

namespace KingPim.Repositories
{
    public interface IProductAttributeValueRepository
    {
        IEnumerable<ProductAttributeValue> ProductAttributeValues { get; }
        IEnumerable<ProductAttributeValue> GetAllProductAttributeValues();
    }
}