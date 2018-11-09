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
        private ISubcategoryRepository _subcatRepo;
        private IProductRepository _productRepo;
        private IProductAttributeValueRepository _productAttrValRepo;
        private IAttributeGroupRepository _attrGroupRepo;
        private ISubcategoryAttributeGroupRepository _subcategoryAttributeGroupRepo;
        public ProductCardBodyTableVC(ISubcategoryRepository subcatRepository, IProductRepository productRepo, IProductAttributeValueRepository productAttrValRepo, IAttributeGroupRepository attributeGroupRepo, ISubcategoryAttributeGroupRepository subcategoryAttributeGroupRepo)
        {
            _subcatRepo = subcatRepository;
            _productRepo = productRepo;
            _productAttrValRepo = productAttrValRepo;
            _attrGroupRepo = attributeGroupRepo;
            _subcategoryAttributeGroupRepo = subcategoryAttributeGroupRepo;
        }

        public IViewComponentResult Invoke(int productId)
        {
            //// The rows where the Products card id matches the ProductAttributeValues product id.
            //var theProdAttrValueRows = _productAttrValRepo.ProductAttributeValues.Where(x => x.ProductId.Equals(productId));
            //foreach (var prodAttrValrow in theProdAttrValueRows)
            //{
            //    // if there is a row in the DB..
            //    if (prodAttrValrow != null)
            //    {
            //        var productAttributeValueVM = new ProductAttributeValueViewModel
            //        {

            //        };
            //        return View(productAttributeValueVM);
            //    }
            //    // there is no row in the DB so send an empty VM to be taken care of in Default.cshtml...
            //    // there is filter
            //    else
            //    {
            //        var productAttributeValueVM = new ProductAttributeValueViewModel
            //        {

            //        };
            //        return View(productAttributeValueVM);
            //    }
            //}





            
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
                if (subcatAttrGroup.SubcategoryId== productsSubcategoryId)
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
                    CardSubcategoryAttributeGroups = theCardsSubcategoryAttributeGroups
                };
                return View(prodAttrValVM);
            }
            












            //// To have all info from the SubcategoryAttributeGroup DB.
            //var subcategoryAttributeGroups = _subcategoryAttributeGroupRepo.SubcategoryAttributeGroups;
            //var theCardsSubcategoryAttributeGroups = new List<AttributeGroup>();
            //// To get each subcatId so can get the subcategories different AttrGroups it has.
            //foreach (var subcatAttrGroup in subcategoryAttributeGroups)
            //{
            //    // if the subcatId matches the products subcategory id, push the attrGroup to the list...
            //    if (subcatAttrGroup.SubcategoryId == productsSubcategoryId)
            //    {
            //        theCardsSubcategoryAttributeGroups.Add(subcatAttrGroup.AttributeGroup);
            //    }
            //}

            //// To have all info from the ProductAttributeValue DB.
            //var productAttributeValues = _productAttrValRepo.ProductAttributeValues;
            //var theCardsProductAttributeValues = new List<ProductAttributeValue>();
            //foreach (var productAttrValueRow in productAttributeValues)
            //{
            //    if (productId == productAttrValueRow.ProductId)
            //    {
            //        theCardsProductAttributeValues.Add(productAttrValueRow);
            //    }
            //}


            //if (theCardsSubcategoryAttributeGroups != null)
            //{

            //    var productAttributeValueVM = new ProductAttributeValueViewModel
            //    {
            //        Id = productId,
            //        AttributeGroups = theCardsSubcategoryAttributeGroups,
            //        ProductAttributeValues = theCardsProductAttributeValues

            //    };

            //    return View(productAttributeValueVM);

            //}
            //else
            //{
            //    var productAttributeValueVM = new ProductAttributeValueViewModel
            //    {

            //    };
            //    return View(productAttributeValueVM);
            //}















            //var theProduct = _productRepo.Products.FirstOrDefault(x => x.Id == productId);
            //var theProductsSubcat = theProduct.Subcategory;
            ////var theProductsSubcatAttributeGroups = theProductsSubcat.SubcategoryAttributeGroups;
            //var theValueRow = _productAttrValRepo.ProductAttributeValues.FirstOrDefault(x => x.ProductId.Equals(productId));

            ////var subcategories = _subcatRepo.Subcategories;

            //if (theValueRow != null)
            //{
            //    var prodAttrValVM = new ProductAttributeValueViewModel
            //    {
            //        Value = theValueRow.Value,
            //        ProductAttributeId = theValueRow.ProductAttributeId,
            //        //ProductId = productId,
            //        //Subcategory = subcategories
            //        //AttributeGroups = theProductsSubcatAttributeGroups
            //    };
            //    return View(prodAttrValVM);
            //}
            //else
            //{
            //    var prodAttrValVM = new ProductAttributeValueViewModel
            //    {
            //        //AttributeGroups = theProductsSubcatAttributeGroups
            //    };
            //    return View(prodAttrValVM);
            //}

        }
    }
}
