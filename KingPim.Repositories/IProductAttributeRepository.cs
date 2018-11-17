using KingPim.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface IProductAttributeRepository
    {
        IEnumerable<ProductAttribute> ProductAttributes { get; }
        IEnumerable<PredefinedListOption> PredefinedListOptions { get; }

        IEnumerable<ProductAttribute> GetAllProductAttributes();

        void AddProductAttribute(AttributeGroupProductAttributeViewModel vm);

        ProductAttribute DeleteProductAttribute(int productAttrId);
    }
}
