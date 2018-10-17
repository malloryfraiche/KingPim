using KingPim.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Data.DataAccess
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<AttributeGroup> AttributeGroup { get; set; }
        public DbSet<ProductAttribute> ProductAttribute { get; set; }
        public DbSet<ProductAttributeValue> ProductAttributeValue { get; set; }
    }
}
