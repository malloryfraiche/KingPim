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
    //[ApiController]
    public class TestController : Controller
    {
        [Route("api/[controller]/[action]")]
        public IActionResult GetJsonCatTestData()
        {
            var catData = TestData.GetTestData();
            return Json(catData);
        }

        [Route("api/[controller]/[action]")]
        public IActionResult GetJsonProductAttrValTestData()
        {
            var productAttrValData = TestData.GetProductAttributeValues();
            return Json(productAttrValData);
        }
    }
}