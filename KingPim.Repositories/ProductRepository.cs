using KingPim.Data.DataAccess;
using KingPim.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KingPim.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext ctx;
        public ProductRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        public IEnumerable<Product> Products => ctx.Products;

        public IEnumerable<Product> GetAllProducts()
        {
            return Products;
        }

        // CREATE and UPDATE product.
        public void AddProduct(ProductViewModel vm)
        {
            if (vm.Id == 0)     // Create
            {
                var newProduct = new Product
                {
                    Name = vm.Name,
                    Description = vm.Description,
                    Price = vm.Price,
                    SubcategoryId = vm.SubcategoryId,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                    Version = 1
                };
                ctx.Products.Add(newProduct);
            }
            else     // Update
            {
                var ctxProduct = ctx.Products.FirstOrDefault(p => p.Id.Equals(vm.Id));
                if (ctxProduct != null)
                {
                    ctxProduct.Name = vm.Name;
                    ctxProduct.Price = vm.Price;
                    ctxProduct.Description = vm.Description;
                    ctxProduct.SubcategoryId = vm.SubcategoryId;
                    ctxProduct.UpdatedDate = DateTime.Now;
                    ctxProduct.Version = ctxProduct.Version + 1;
                }
            }
            ctx.SaveChanges();
        }

        public Product DeleteProduct(int productId)
        {
            var ctxProduct = ctx.Products.FirstOrDefault(p => p.Id.Equals(productId));
            if (ctxProduct != null)
            {
                ctx.Products.Remove(ctxProduct);
                ctx.SaveChanges();
            }
            return ctxProduct;
        }

        public void PublishProduct(ProductViewModel vm)
        {
            var ctxProduct = ctx.Products.FirstOrDefault(p => p.Id.Equals(vm.Id));
            if (ctxProduct != null)
            {
                // The products subcategory.
                var ctxSubcategory = ctx.Subcategories.FirstOrDefault(s => s.Id.Equals(ctxProduct.SubcategoryId));
                // The products subcategories category.
                var ctxCategory = ctx.Categories.FirstOrDefault(c => c.Id.Equals(ctxSubcategory.CategoryId));

                if (!ctxProduct.Published)
                {
                    ctxProduct.Published = true;
                    ctxSubcategory.Published = true;
                    ctxCategory.Published = true;
                }
                else
                {
                    ctxProduct.Published = false;

                    // If all the subcategory products have false (unpublished) for all products, then the subcategory needs to also be false (unpublished).
                    if (ctxSubcategory.Products.Count(p => p.Published) == 0)
                    {
                        ctxSubcategory.Published = false;
                    }
                    // If all the category subcategories have false (unpublished) for all subcats, then the category needs to also be false (unpublished).
                    if (ctxCategory.Subcategories.Count(s => s.Published) == 0)
                    {
                        ctxCategory.Published = false;
                    }
                }
                ctx.SaveChanges();
            }
        }

        // ADD and UPDATE product attribute value.
        public void SaveProductAttributeValue(ProductAttributeValueViewModel vm)
        {
            if (vm.Id == 0)     // Add
            {
                var row = ctx.ProductAttributeValues.FirstOrDefault(x => x.ProductAttributeId.Equals(vm.ProductAttributeId) && x.ProductId.Equals(vm.ProductId));
                if (row == null)
                {
                    var productAttributeValue = new ProductAttributeValue
                    {
                        Value = vm.Value,
                        ProductAttributeId = vm.ProductAttributeId,
                        ProductId = vm.ProductId
                    };
                    ctx.ProductAttributeValues.Add(productAttributeValue);
                }
                else
                {
                    ctx.ProductAttributeValues.Remove(row);
                    ctx.SaveChanges();

                    var productAttributeValue = new ProductAttributeValue
                    {
                        Value = vm.Value,
                        ProductAttributeId = vm.ProductAttributeId,
                        ProductId = vm.ProductId
                    };
                    ctx.ProductAttributeValues.Add(productAttributeValue);
                }
                
            }
            ctx.SaveChanges();
        }
    }
}
