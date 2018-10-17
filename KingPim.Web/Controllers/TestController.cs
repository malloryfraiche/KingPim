using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class TestController : Controller
    {
        private List<Category> GetTestData()
        {
            var subcatList = new List<Subcategory>();
            var subcategoryDataOne = new Subcategory
            {
                Id = 1,
                Name = "Equiptment"
            };
            subcatList.Add(subcategoryDataOne);

            var categoryList = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Basket",
                    Subcategories = subcatList
                },
                new Category
                {
                    Id = 2,
                    Name = "Alpint",
                    Subcategories = subcatList
                },
                new Category
                {
                    Id = 3,
                    Name = "Crossfit",
                    Subcategories = subcatList
                }
            };

            return categoryList;
        }

        public IActionResult GetJsonTestData()
        {
            var data = GetTestData();
            return Json(data);
        }
    }
}