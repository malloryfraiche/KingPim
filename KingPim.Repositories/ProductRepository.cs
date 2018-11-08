using KingPim.Data.DataAccess;
using KingPim.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                //var ctxSubcategory = ctx.Subcategories.FirstOrDefault(x => x.Id.Equals(vm.Id));
                //if (ctxSubcategory != null)
                //{
                //    ctxSubcategory.Name = vm.Name;
                //    ctxSubcategory.CategoryId = vm.CategoryId;
                //    ctxSubcategory.UpdatedDate = DateTime.Now;
                //    ctxSubcategory.Version = ctxSubcategory.Version + 1;
                //}
            }
            ctx.SaveChanges();
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
    }
}
