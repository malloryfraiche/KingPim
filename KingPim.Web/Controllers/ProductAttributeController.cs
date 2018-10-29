using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KingPim.Web.Controllers
{
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
            return RedirectToAction(nameof(Index));
        }
    }
}