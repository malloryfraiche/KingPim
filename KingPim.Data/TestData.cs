using KingPim.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPim.Data
{
    public class TestData
    {
        public static List<Category> GetTestData()
        {
            var productAttributeListOne = new List<ProductAttribute>();
            var productAttributeDataOne = new ProductAttribute
            {
                Id = 1,
                Name = "Röd",
                Description = "Färg röd.",
                Type = "string",
                AttributeGroupId = 1
            };
            var productAttributeDataTwo = new ProductAttribute
            {
                Id = 2,
                Name = "Blå",
                Description = "Färg blå.",
                Type = "string",
                AttributeGroupId = 1
            };
            productAttributeListOne.Add(productAttributeDataOne);
            productAttributeListOne.Add(productAttributeDataTwo);

            var productAttributeListTwo = new List<ProductAttribute>();
            var productAttributeDataThree = new ProductAttribute
            {
                Id = 3,
                Name = "Batteri",
                Description = "Behöver produkt batterier?",
                Type = "bool",
                AttributeGroupId = 2
            };
            productAttributeListTwo.Add(productAttributeDataThree);

            var attributeGroupListOne = new List<AttributeGroup>();
            var attributeGroupDataOne = new AttributeGroup
            {
                Id = 1,
                Name = "Färg",
                Description = "Färg av produkt.",
                ProductAttributes = productAttributeListOne
            };
            var attributeGroupDataTwo = new AttributeGroup
            {
                Id = 2,
                Name = "Teknisk",
                Description = "Alla information om produktens teknisk behövs.",
                ProductAttributes = productAttributeListTwo
            };
            attributeGroupListOne.Add(attributeGroupDataOne);
            attributeGroupListOne.Add(attributeGroupDataTwo);
            
            var productListOne = new List<Product>();
            var productDataOne = new Product
            {
                Id = 1,
                Name = "Titlest ProV1 Balls",
                Description = "Ett dussin högeffektiv bollar som många proffs använda.",
                Price = 350,
                SubcategoryId = 1,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1.0
            };
            var productDataTwo = new Product
            {
                Id = 2,
                Name = "Ping Bag",
                Description = "Modernt och lättvikt golfbag optimal för att har i alla typ av väder.",
                Price = 750,
                SubcategoryId = 1,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1.0
            };
            productListOne.Add(productDataOne);
            productListOne.Add(productDataTwo);
            
            var productListTwo = new List<Product>();
            var productDataThree = new Product
            {
                Id = 3,
                Name = "ECCO Shoes",
                Description = "Vattentät och bekväm skor som man kan gå i flera timma utan skosår.",
                Price = 1200,
                SubcategoryId = 2,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1.0
            };
            var productDataFour = new Product
            {
                Id = 4,
                Name = "Nike Polo Shirt",
                Description = "Passformen är precis lagom, inte för tight och inte för löst sittande.",
                Price = 395,
                SubcategoryId = 2,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1.0
            };
            productListTwo.Add(productDataThree);
            productListTwo.Add(productDataFour);
            
            var subcatListOne = new List<Subcategory>();
            var subcategoryDataOne = new Subcategory
            {
                Id = 1,
                Name = "Utrustning",
                CategoryId = 1,
                Products = productListOne,
                AttributeGroups = attributeGroupListOne,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1.0
            };
            var subcategoryDataTwo = new Subcategory
            {
                Id = 2,
                Name = "Kläder",
                CategoryId = 1,
                Products = productListTwo,
                AttributeGroups = attributeGroupListOne,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1.0
            };
            subcatListOne.Add(subcategoryDataOne);
            subcatListOne.Add(subcategoryDataTwo);

            var categoryList = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Golf",
                    Subcategories = subcatListOne,
                    UpdatedDate = DateTime.Now.Date,
                    AddedDate = DateTime.Today,
                    Published = false,
                    Version = 1.0
                }
            };

            return categoryList;
        }

        public static List<ProductAttributeValue> GetProductAttributeValues()
        {
            var productAttributeValueList = new List<ProductAttributeValue>();

            var categoryList = GetTestData();
            var cat = categoryList.FirstOrDefault(x => x.Id == 1);
            var subCat = cat.Subcategories.FirstOrDefault(x => x.Id == 1);
            var product = subCat.Products.FirstOrDefault(x => x.Id == 2);

            var prodAttributeValOne = new ProductAttributeValue
            {
                Id = 1,
                Value = "Röd",
                ProductAttributeId = 1,
                ProductId = 2,
                Product = product
            };
            var prodAttributeValTwo = new ProductAttributeValue
            {
                Id = 2,
                Value = "Röd",
                ProductAttributeId = 1,
                ProductId = 3
            };
            var prodAttributeValThree = new ProductAttributeValue
            {
                Id = 3,
                Value = "true",
                ProductAttributeId = 3,
                ProductId = 1
            };
            productAttributeValueList.Add(prodAttributeValOne);
            productAttributeValueList.Add(prodAttributeValTwo);
            productAttributeValueList.Add(prodAttributeValThree);

            return productAttributeValueList;
        }

    }
}
