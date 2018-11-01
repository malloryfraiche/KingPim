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
    }
}
