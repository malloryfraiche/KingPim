using KingPim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

        IEnumerable<Product> GetAllProducts();
    }
}
