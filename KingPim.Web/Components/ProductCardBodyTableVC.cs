using KingPim.Models;
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
        private IProductRepository _productRepo;
        private IProductAttributeValueRepository _productAttrValRepo;
        private ISubcategoryAttributeGroupRepository _subcategoryAttributeGroupRepo;
        public ProductCardBodyTableVC(IProductRepository productRepo, IProductAttributeValueRepository productAttrValRepo, ISubcategoryAttributeGroupRepository subcategoryAttributeGroupRepo)
        {
            _productRepo = productRepo;
            _productAttrValRepo = productAttrValRepo;
            _subcategoryAttributeGroupRepo = subcategoryAttributeGroupRepo;
        }

        public IViewComponentResult Invoke(int productId)
        {
            // To get the product (from the product id the card passed in).
            var theProduct = _productRepo.Products.FirstOrDefault(p => p.Id.Equals(productId));
            // To get the products subcategory.
            var productsSubcategoryId = theProduct.Subcategory.Id;
            // To have all info from the ProductAttributeValue DB.
            var productAttributeValues = _productAttrValRepo.ProductAttributeValues;
            // List to store the specific cards product attribute value data.
            var theCardsProductAttributeValues = new List<ProductAttributeValue>();
            foreach (var productAttrValueRow in productAttributeValues)
            {
                if (productId == productAttrValueRow.ProductId)
                {
                    theCardsProductAttributeValues.Add(productAttrValueRow);
                }
            }
            // To have all info from the SubcategoryAttributeGroup DB.
            var subcategoryAttributeGroups = _subcategoryAttributeGroupRepo.SubcategoryAttributeGroups;
            var theCardsSubcategoryAttributeGroups = new List<SubcategoryAttributeGroup>();
            // To get each subcatId so can get the subcategories different AttrGroups it has.
            foreach (var subcatAttrGroup in subcategoryAttributeGroups)
            {
                // if the subcatId matches the products subcategory id, push the subcategory attribute group row to the list...
                if (subcatAttrGroup.SubcategoryId == productsSubcategoryId)
                {
                    theCardsSubcategoryAttributeGroups.Add(subcatAttrGroup);
                }
            }
            // To send in filtered info for the specific product on the card.
            // If the product has information in the ProductAttributeValue DB table...
            if (theCardsProductAttributeValues.Any())
            {
                var prodAttrValVM = new ProductAttributeValueViewModel
                {
                    ProductId = productId,
                    CardProductAttributeValues = theCardsProductAttributeValues,
                    CardSubcategoryAttributeGroups = theCardsSubcategoryAttributeGroups
                };
                return View(prodAttrValVM);
            }
            // If not just show all the product attributes connected to the products subcategory (the 'value' from the ProductAttributeValue DB table will be empty)..
            else
            {
                var prodAttrValVM = new ProductAttributeValueViewModel
                {
                    ProductId = productId,
                    CardSubcategoryAttributeGroups = theCardsSubcategoryAttributeGroups
                };
                return View(prodAttrValVM);
            }
        }
    }
}