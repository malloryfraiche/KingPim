using KingPim.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface ISubcategoryRepository
    {
        IEnumerable<Subcategory> Subcategories { get; }

        IEnumerable<Subcategory> GetAllSubcategories();

        void AddSubcategory(AddSubcategoryViewModel vm);

        Subcategory DeleteSubcategory(int subcategoryId);

        void PublishSubcategory(AddSubcategoryViewModel vm);
    }
}
