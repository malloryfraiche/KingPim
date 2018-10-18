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
            var productAttributeList = new List<ProductAttribute>();
            var productAttributeDataOne = new ProductAttribute
            {
                Name = "Röd",
                Description = "Färg röd.",
                Type = "string",
            };
            var productAttributeDataTwo = new ProductAttribute
            {
                Name = "Blå",
                Description = "Färg blå.",
                Type = "string",
            };
            productAttributeList.Add(productAttributeDataOne);
            productAttributeList.Add(productAttributeDataTwo);

            var productAttributeList2 = new List<ProductAttribute>();
            var productAttributeDataThree = new ProductAttribute
            {
                Name = "Batteri",
                Description = "Behöver produkt batterier?",
                Type = "bool",
            };
            productAttributeList2.Add(productAttributeDataThree);

            var attributeGroupList = new List<AttributeGroup>();
            var attributeGroupDataOne = new AttributeGroup
            {
                Name = "Färg",
                Description = "Färg av produkt.",
                ProductAttributes = productAttributeList
            };
            var attributeGroupDataTwo = new AttributeGroup
            {
                Name = "Teknisk",
                Description = "Alla information om produktens teknisk behövs.",
                ProductAttributes = productAttributeList2
            };
            attributeGroupList.Add(attributeGroupDataOne);
            attributeGroupList.Add(attributeGroupDataTwo);

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

            var subcatList = new List<Subcategory>();
            var subcategoryDataOne = new Subcategory
            {
                Name = "Utrustning",
                Products = productList,
                AttributeGroups = attributeGroupList,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1.0
            };
            var subcategoryDataTwo = new Subcategory
            {
                Name = "Kläder",
                Products = productList2,
                AttributeGroups = attributeGroupList,
                UpdatedDate = DateTime.Now.Date,
                AddedDate = DateTime.Today,
                Published = false,
                Version = 1.0
            };
            subcatList.Add(subcategoryDataOne);
            subcatList.Add(subcategoryDataTwo);

            if (!ctx.Categories.Any())
            {
                var categoryList = new List<Category>
                {
                    new Category
                    {
                        Name = "Golf",
                        Subcategories = subcatList,
                        UpdatedDate = DateTime.Now.Date,
                        AddedDate = DateTime.Today,
                        Published = false,
                        Version = 1.0
                    }
                };
                ctx.Categories.AddRange(categoryList);
            }
            
            ctx.SaveChanges();
        }
    }
}