using KingPim.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }


        IEnumerable<Category> GetAllCategories();

        void SaveCategory(Category category);
    }
}
