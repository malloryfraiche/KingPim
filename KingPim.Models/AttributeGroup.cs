using System;
using System.Collections.Generic;
using System.Text;

namespace KingPim.Models
{
    public class AttributeGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public virtual Subcategory Subcategory { get; set; }
        //public int? SubcategoryId { get; set; }
        public virtual List<ProductAttribute> ProductAttributes { get; set; }

        //public virtual List<Subcategory> Subcategories { get; set; }
        //public virtual List<SubcategoryAttributeGroup> SubcategoryAttributeGroups { get; set; }
    }
}
