using KingPim.Models;
using KingPim.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }

        //IEnumerable<IdentityRole> Roles { get; }

        IEnumerable<Category> GetAllCategories();

        void AddCategory(AddCategoryViewModel vm);

        Category DeleteCategory(int categoryId);

        void PublishCategory(AddCategoryViewModel vm);

        //IEnumerable<Category> Search(string searchString);
    }
}
