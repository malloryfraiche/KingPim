using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Data;
using KingPim.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TestController : Controller
    {
        

        //public IActionResult GetProduct(int id)
        //{
        //    var vm = new ProductViewModel
        //    {
        //        Categories = TestData.GetTestData(),
        //        Pav = TestData.GetProductAttributeValues()
        //    };

        //    return Json(vm);
        //}


    }

    //public class ProductViewModel
    //{
    //    public List<Category> Categories { get; set; }
    //    public List<ProductAttributeValue> Pav { get; set; }
    //}
}