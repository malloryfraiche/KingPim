using KingPim.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

        IEnumerable<Category> GetAllCategories();

        void AddCategory(AddCategoryViewModel vm);

        Category DeleteCategory(int categoryId);

        //void SaveCategory(Category category);
    }
}
