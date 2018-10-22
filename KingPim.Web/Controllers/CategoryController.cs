using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Models;
using KingPim.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class CategoryController : Controller
    {
        private ICategoryRepository _categoryRepo;

        public CategoryController(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        
        [HttpGet]
        public IActionResult GetCategories()
        {
            var categories = _categoryRepo.GetAllCategories();

            return Json(categories);
        }

    }
}