using KingPim.Models;
using KingPim.Models.ViewModels;
using System.Collections.Generic;

namespace KingPim.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<Product> GetAllProducts();
        void AddProduct(ProductViewModel vm);
        Product DeleteProduct(int productId);
        void PublishProduct(ProductViewModel vm);
        void SaveProductAttributeValue(ProductAttributeValueViewModel vm);
    }
}