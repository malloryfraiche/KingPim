using KingPim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPim.Data.DataAccess
{
    public class Seed
    {
        public static void FillIfEmpty(ApplicationDbContext ctx)
        {
            // ----- Adding seed data for Product Attributes -----
            // Product Attribute list 1 - for attribute group 'Style'
            var productAttributeList = new List<ProductAttribute>();
            var productAttributeDataOne = new ProductAttribute
            {
                Name = "Color",
                Description = "The main color of the product.",
                Type = "string",
            };
            var productAttributeDataTwo = new ProductAttribute
            {
                Name = "Material",
                Description = "The different materials the product is made out of.",
                Type = "string",
            };
            productAttributeList.Add(productAttributeDataOne);
            productAttributeList.Add(productAttributeDataTwo);
            // Product Attribute list 2 - for attribute group 'Equiptment'
            var productAttributeList2 = new List<ProductAttribute>();
            var productAttributeDataThree = new ProductAttribute
            {
                Name = "Sale",
                Description = "Is this product on sale?",
                Type = "bool",
            };
            var productAttributeDataFour = new ProductAttribute
            {
                Name = "Battery",
                Description = "Does this product need batteries?",
                Type = "bool",
            };
            productAttributeList2.Add(productAttributeDataThree);
            productAttributeList2.Add(productAttributeDataFour);
            
            // ----- Adding seed data for Attribute Groups + Saving all information -----
            if (!ctx.AttributeGroups.Any())
            {
                // Attribute Group data 1
                var attributeGroupDataOne = new AttributeGroup
                {
                    Name = "Specifications",
                    Description = "Details about the product.",
                    ProductAttributes = productAttributeList2
                };
                // Attribute Group data 2 
                var attributeGroupDataTwo = new AttributeGroup
                {
                    Name = "Style",
                    Description = "Here you can choose what style you are after. For example, color or material.",
                    ProductAttributes = productAttributeList
                };
                ctx.AttributeGroups.Add(attributeGroupDataOne);
                ctx.AttributeGroups.Add(attributeGroupDataTwo);

                ctx.SaveChanges();
            }
            
            // ----- Adding seed data for Products -----
            // Product list 1 - products for subcategory 'Equiptment'
            var productList = new List<Product>();
            var productDataOne = new Product
            {
                Name = "Titlest ProV1 Balls",
                Description = "Ett dussin högeffektiv bollar som många proffs använda.",
                Price = 350,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1.0
            };
            var productDataTwo = new Product
            {
                Name = "Ping Bag",
                Description = "Modernt och lättvikt golfbag optimal för att har i alla typ av väder.",
                Price = 750,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1.0
            };
            productList.Add(productDataOne);
            productList.Add(productDataTwo);
            // Product list 2 - products for subcategory 'Clothes'
            var productList2 = new List<Product>();
            var productDataThree = new Product
            {
                Name = "ECCO Shoes",
                Description = "Vattentät och bekväm skor som man kan gå i flera timma utan skosår.",
                Price = 1200,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1.0
            };
            var productDataFour = new Product
            {
                Name = "Nike Polo Shirt",
                Description = "Passformen är precis lagom, inte för tight och inte för löst sittande.",
                Price = 395,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1.0
            };
            productList2.Add(productDataThree);
            productList2.Add(productDataFour);
            
            // ----- Adding seed data for SubcategoryAttributeGroups -----
            // the 'Equiptment' subcategory...
            var subcatId1Connection = ctx.Subcategories.FirstOrDefault(s => s.Id == 1);
            // the 'Clothes' subcategory...
            var subcatId2Connection = ctx.Subcategories.FirstOrDefault(s => s.Id == 2);
            // the 'Specifications' attribute group...
            var attrGroupId1Connection = ctx.AttributeGroups.FirstOrDefault(a => a.Id == 1);
            // the 'Style' attribute group...
            var attrGroupId2Connection = ctx.AttributeGroups.FirstOrDefault(a => a.Id == 2);
            // This is for the 'Equiptment' subcategory connection.
            var subcatAttrGroupList1 = new List<SubcategoryAttributeGroup>();
            var subcatAttrGroupConnection1 = new SubcategoryAttributeGroup
            {
                Subcategory = subcatId1Connection,
                AttributeGroup = attrGroupId1Connection
            };
            var subcatAttrGroupConnection2 = new SubcategoryAttributeGroup
            {
                Subcategory = subcatId1Connection,
                AttributeGroup = attrGroupId2Connection
            };
            subcatAttrGroupList1.Add(subcatAttrGroupConnection1);
            subcatAttrGroupList1.Add(subcatAttrGroupConnection2);
            // This is for the 'Clothes' subcategory connection.
            var subcatAttrGroupList2 = new List<SubcategoryAttributeGroup>();
            var subcatAttrGroupConnection3 = new SubcategoryAttributeGroup
            {
                Subcategory = subcatId2Connection,
                AttributeGroup = attrGroupId1Connection
            };
            var subcatAttrGroupConnection4 = new SubcategoryAttributeGroup
            {
                Subcategory = subcatId2Connection,
                AttributeGroup = attrGroupId2Connection
            };
            subcatAttrGroupList2.Add(subcatAttrGroupConnection3);
            subcatAttrGroupList2.Add(subcatAttrGroupConnection4);


            // ----- Adding Seed data for Subcategory -----
            var subcatList = new List<Subcategory>();
            var subcategoryDataOne = new Subcategory
            {
                Name = "Equiptment",
                Products = productList,
                SubcategoryAttributeGroups = subcatAttrGroupList1,
                UpdatedDate = DateTime.Now,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1.0
            };
            var subcategoryDataTwo = new Subcategory
            {
                Name = "Clothes",
                Products = productList2,
                SubcategoryAttributeGroups = subcatAttrGroupList2,
                UpdatedDate = DateTime.Now,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1.0
            };
            subcatList.Add(subcategoryDataOne);
            subcatList.Add(subcategoryDataTwo);

            // ----- Adding Seed data for Category + Saving all information -----
            if (!ctx.Categories.Any())
            {
                var categoryList = new List<Category>
                {
                    new Category
                    {
                        Name = "Golf",
                        Subcategories = subcatList,
                        UpdatedDate = DateTime.Now,
                        AddedDate = DateTime.Today,
                        Published = false,
                        Version = 1.0
                    }
                };
                ctx.Categories.AddRange(categoryList);

                ctx.SaveChanges();
            }

            // ----- Adding Seed data for ProductAttributeValue + Saving all information -----
            if (!ctx.ProductAttributeValues.Any())
            {
                // the 'Nike Shirt' product..
                var productConnection1 = ctx.Products.FirstOrDefault(x => x.Id == 4);
                // the 'Color' productAttribute...
                var productAttConnection1 = ctx.ProductAttributes.FirstOrDefault(x => x.Id == 3);
                var prodAttrVal1 = new ProductAttributeValue
                {
                    Value = "Red",
                    Product = productConnection1,
                    ProductAttribute = productAttConnection1
                };
                ctx.ProductAttributeValues.Add(prodAttrVal1);

                // the 'Ecco Shoes' product..
                var productConnection2 = ctx.Products.FirstOrDefault(x => x.Id == 3);
                // the 'Color' productAttribute..
                var productAttConnection2 = ctx.ProductAttributes.FirstOrDefault(x => x.Id == 3);
                var prodAttrVal2 = new ProductAttributeValue
                {
                    Value = "Blue",
                    Product = productConnection2,
                    ProductAttribute = productAttConnection2
                };
                ctx.ProductAttributeValues.Add(prodAttrVal2);

                // the 'Titlest ProV1 Balls' product..
                var productConnection3 = ctx.Products.FirstOrDefault(x => x.Id == 1);
                // the 'Battery' productAttribute..
                var productAttConnection3 = ctx.ProductAttributes.FirstOrDefault(x => x.Id == 2);
                var prodAttrVal3 = new ProductAttributeValue
                {
                    Value = "No",
                    Product = productConnection3,
                    ProductAttribute = productAttConnection3
                };
                ctx.ProductAttributeValues.Add(prodAttrVal3);

                // the 'Ping Golf Bag' product..
                var productConnection4 = ctx.Products.FirstOrDefault(x => x.Id == 2);
                // the 'Sale' productAttribute..
                var productAttConnection4 = ctx.ProductAttributes.FirstOrDefault(x => x.Id == 1);
                var prodAttrVal4 = new ProductAttributeValue
                {
                    Value = "Yes",
                    Product = productConnection4,
                    ProductAttribute = productAttConnection4
                };
                ctx.ProductAttributeValues.Add(prodAttrVal4);

                ctx.SaveChanges();
            }
        }
    }
}