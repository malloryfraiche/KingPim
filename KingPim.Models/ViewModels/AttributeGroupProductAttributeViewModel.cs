using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models.ViewModels
{
    public class AttributeGroupProductAttributeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SubcategoryId { get; set; }      // AttributeGroup usage.
        public IEnumerable<Subcategory> Subcategory { get; set; }     // AttributeGroup usage.
        public string Type { get; set; }            // ProductAttribute usage.
        public int AttributeGroupId { get; set; }   // ProductAttribute usage.
        public IEnumerable<AttributeGroup> AttributeGroup { get; set; }     // ProductAttribute usage.
    }
}
