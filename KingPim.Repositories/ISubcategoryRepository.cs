using KingPim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface ISubcategoryRepository
    {
        IEnumerable<Subcategory> Subcategories { get; }

        IEnumerable<Subcategory> GetAllSubcategories();
    }
}
