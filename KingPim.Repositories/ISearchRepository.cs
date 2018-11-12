using KingPim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface ISearchRepository
    {
        IEnumerable<Subcategory> Subcategories { get; }
        IEnumerable<Category> Categories { get; }
        IEnumerable<Product> Products { get; }
    }
}
