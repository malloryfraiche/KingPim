using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Components
{
    public class AddNewVC : ViewComponent
    {
        private ICategoryRepository _categoryRepo;
        public AddNewVC(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public string Invoke()
        {
            var test = "Hello from the AddNewVC!";
            return test;
        }
    }
}
