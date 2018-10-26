﻿using KingPim.Data.DataAccess;
using KingPim.Models;
using KingPim.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KingPim.Repositories
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        // Injecting DB connection to SubcategoryRepository (DI)..
        public ApplicationDbContext ctx;
        public SubcategoryRepository(ApplicationDbContext context)
        {
            ctx = context;
        }

        public IEnumerable<Subcategory> Subcategories => ctx.Subcategories;


        public IEnumerable<Subcategory> GetAllSubcategories()
        {
            return Subcategories;
        }

        // CREATE and UPDATE subcategory.
        public void AddSubcategory(AddSubcategoryViewModel vm)
        {
            if (vm.Id == 0)     // Create
            {
                var newSubcat = new Subcategory
                {
                    Name = vm.Name,
                    CategoryId = vm.CategoryId,
                    Products = null,
                    AttributeGroups = null,
                    AddedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    Published = false,
                    Version = 1
                };
                ctx.Subcategories.Add(newSubcat);
            }
            else     // Update
            {
                var ctxSubcategory = ctx.Subcategories.FirstOrDefault(x => x.Id.Equals(vm.Id));
                if (ctxSubcategory != null)
                {
                    ctxSubcategory.Name = vm.Name;
                    ctxSubcategory.CategoryId = vm.CategoryId;
                    ctxSubcategory.UpdatedDate = DateTime.Now;
                    ctxSubcategory.Version = vm.Version + 1;
                }
            }

            ctx.SaveChanges();
        }
    }
}
