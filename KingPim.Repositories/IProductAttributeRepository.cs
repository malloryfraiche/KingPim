using KingPim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface IProductAttributeRepository
    {
        IEnumerable<ProductAttribute> ProductAttributes { get; }

        IEnumerable<ProductAttribute> GetAllProductAttributes();
    }
}
