using KingPim.Models.ViewModels;
using KingPim.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KingPim.Web.Components
{
    public class ProductCardBodyTableVC : ViewComponent
    {
        private ISubcategoryRepository _subcatRepo;
        private IProductRepository _productRepo;
        private IProductAttributeValueRepository _productAttrValRepo;
        private IAttributeGroupRepository _attrGroupRepo;
        public ProductCardBodyTableVC(ISubcategoryRepository subcatRepository, IProductRepository productRepo, IProductAttributeValueRepository productAttrValRepo, IAttributeGroupRepository attributeGroupRepo)
        {
            _subcatRepo = subcatRepository;
            _productRepo = productRepo;
            _productAttrValRepo = productAttrValRepo;
            _attrGroupRepo = attributeGroupRepo;
        }

        public IViewComponentResult Invoke(int productId)
        {
            var theProduct = _productRepo.Products.FirstOrDefault(x => x.Id == productId);
            var theProductsSubcat = theProduct.Subcategory;
            //var theProductsSubcatAttributeGroups = theProductsSubcat.SubcategoryAttributeGroups;
            var theValueRow = _productAttrValRepo.ProductAttributeValues.FirstOrDefault(x => x.ProductId.Equals(productId));

            //var subcategories = _subcatRepo.Subcategories;

            if (theValueRow != null)
            {
                var prodAttrValVM = new ProductAttributeValueViewModel
                {
                    Value = theValueRow.Value,
                    ProductAttributeId = theValueRow.ProductAttributeId,
                    //ProductId = productId,
                    //Subcategory = subcategories
                    //AttributeGroups = theProductsSubcatAttributeGroups
                };
                return View(prodAttrValVM);
            }
            else
            {
                var prodAttrValVM = new ProductAttributeValueViewModel
                {
                    //AttributeGroups = theProductsSubcatAttributeGroups
                };
                return View(prodAttrValVM);
            }
            
        }
    }
}
