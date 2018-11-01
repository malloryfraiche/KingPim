using KingPim.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        IEnumerable<Product> GetAllProducts();

        void AddProduct(ProductViewModel vm);
    }
}
