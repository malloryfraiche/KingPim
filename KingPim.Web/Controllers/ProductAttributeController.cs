using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
    [Authorize]
    public class ProductAttributeController : Controller
    {
        private IProductAttributeRepository _productAttrRepo;
        public ProductAttributeController(IProductAttributeRepository productAttributeRepository)
        {
            _productAttrRepo = productAttributeRepository;
        }

        public IActionResult Index()
        {
            var productAttributes = _productAttrRepo.GetAllProductAttributes();
            ViewBag.TitlePlural = "Product Attributes";
            ViewBag.Title = "Product Attribute";
            return View(productAttributes);
        }

        [HttpPost]
        public IActionResult AddProductAttribute(AttributeGroupProductAttributeViewModel vm)
        {
            _productAttrRepo.AddProductAttribute(vm);
            var url = Url.Action("Index", "ProductAttribute");
            return Json(url);
        }
        
        [HttpGet]
        public IActionResult GetPredefinedListOptionsToJson()
        {
            var allPredefinedListOptions = _productAttrRepo.PredefinedListOptions;
            return Json(allPredefinedListOptions);
        }

        [HttpPost]
        public IActionResult DeleteProductAttribute(int productAttrId)
        {
            var deletedProductAttr = _productAttrRepo.DeleteProductAttribute(productAttrId);
            if (deletedProductAttr != null)
            {
                // error - product attribute was found and not deleted for some reason.
            }
            else
            {
                // error - product attribute was not found in DB.
            }
            return RedirectToAction(nameof(Index));
        }
    }
}