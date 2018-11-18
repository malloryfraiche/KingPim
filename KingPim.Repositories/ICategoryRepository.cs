using KingPim.Models;
using KingPim.Models.ViewModels;
using System.Collections.Generic;

namespace KingPim.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
        IEnumerable<Category> GetAllCategories();
        void AddCategory(AddCategoryViewModel vm);
        Category DeleteCategory(int categoryId);
        void PublishCategory(AddCategoryViewModel vm);
    }
}